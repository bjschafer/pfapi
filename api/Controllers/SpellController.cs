using api.Data;
using api.Models.Database;
using api.Models.Request;
using api.Models.Response;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpellController : ControllerBase
{
    private readonly ApiContext               _context;
    private readonly ILogger<SpellController> _logger;
    private readonly IMapper                  _mapper;

    public SpellController(ApiContext context, IMapper mapper, ILogger<SpellController> logger)
    {
        _context = context;
        _mapper  = mapper;
        _logger  = logger;
    }

    private string? ValidatePagination(int page, int limit)
    {
        if (page < 1)
        {
            return $"Invalid page {page}: must be greater than zero.";
        }
        if (limit > 100)
        {
            return $"Limit {limit} too high; keep it below 100";
        }

        return null;
    }

    /// <summary>
    ///     Get all spells
    /// </summary>
    /// <returns>A JSON list containing all spells in the database</returns>
    /// <param name="page">Page number of results to get</param>
    /// <param name="limit">Number of results to return (max 100)</param>
    /// <response code="200">Returns up to limit spells</response>
    /// <response code="400">Error validating parameters -- keep limit below 100</response>
    [HttpGet]
    public async Task<ActionResult<List<SpellResponse>>> GetSpell(int page = 1, int limit = 20)
    {
        var validPagination = ValidatePagination(page, limit);
        if (validPagination is not null)
        {
            return BadRequest(validPagination);
        }
        var spells = await _context.Spell
                                   .Include(s => s.Descriptors)
                                   .Include(s => s.Source)
                                   .Skip((page - 1) * limit)
                                   .Take(limit)
                                   .ToListAsync();
        var mappedSpells = _mapper.Map<List<SpellResponse>>(spells);
        return Ok(mappedSpells);
    }

    /// <summary>
    ///     Get a spell with a specific name
    /// </summary>
    /// <param name="name">The spell's exact name</param>
    /// <returns>A JSON object representing the given spell, if it exists</returns>
    /// <response code="200">Returns the spell</response>
    /// <response code="404">Spell with given ID not found</response>
    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SpellResponse>> GetSpell(string name)
    {
        var spell = await _context.Spell
                                  .Include(s => s.Descriptors)
                                  .Include(s => s.Source)
                                  .FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());

        if (spell == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SpellResponse>(spell));
    }

    /// <summary>
    ///     Get all spells on a given class list
    /// </summary>
    /// <param name="className">Class to search for, e.g. Wizard</param>
    /// <param name="level">Optional class level to filter down to</param>
    /// <param name="page">Page number of results to get</param>
    /// <param name="limit">Number of results to return (max 100)</param>
    /// <returns>Spells that class can cast</returns>
    /// <response code="200">Returns requested spells, up to limit</response>
    /// <response code="400">Error validating parameters -- keep limit below 100</response>
    /// <response code="404">The class you specified wasn't found</response>
    [HttpGet("Class/{className}")]
    public async Task<ActionResult<List<SpellResponse>>> GetSpellsByClass(string className, int? level, int page = 1, int limit = 20)
    {
        var validPagination = ValidatePagination(page, limit);
        if (validPagination is not null)
        {
            return BadRequest(validPagination);
        }
        var desiredClass = await _context.Class
                                         .FirstOrDefaultAsync(c => c.Name.ToLower() == className.ToLower());
        if (desiredClass is null)
        {
            return NotFound($"Class {className} not found");
        }

        List<Spell> spells;
        if (level is null)
        {
            spells = await _context.Spell
                                   .Include(s => s.Descriptors)
                                   .Include(s => s.Source)
                                   .Where(s => s.ClassLevels.Any(cl => cl.ClassName == className))
                                   .Skip((page - 1) * limit)
                                   .Take(limit)
                                   .ToListAsync();
        }
        else
        {
            spells = await _context.Spell
                                   .Include(s => s.Descriptors)
                                   .Include(s => s.Source)
                                   .Where(s => s.ClassLevels.Any(cl => cl.ClassName == className && cl.Level == level))
                                   .Skip((page - 1) * limit)
                                   .Take(limit)
                                   .ToListAsync();
        }
        var mappedSpells = _mapper.Map<List<SpellResponse>>(spells);
        return Ok(mappedSpells);
    }

    /// <summary>
    ///     Update a spell
    /// </summary>
    /// <param name="id"></param>
    /// <param name="spellRequest"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutSpell(int id, SpellRequest spellRequest)
    {
        var existingSpell = await _context.Spell.FindAsync(id);
        if (existingSpell is null)
        {
            return NotFound();
        }
        var spell = _mapper.Map(spellRequest, existingSpell);

        _context.Entry(spell!).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>
    ///     Create a new spell
    /// </summary>
    /// <param name="spellRequest"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Spell>> PostSpell([FromBody] SpellRequest spellRequest)
    {
        var spell = await MapSpellRequestToSpell(spellRequest);
        // TODO validate classes contained are valid

        _context.Spell.Add(spell);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSpell), new
        {
            id = spell.Id,
        }, spellRequest);
    }
    private async Task<Spell> MapSpellRequestToSpell(SpellRequest spellRequest)
    {
        var spell = _mapper.Map<Spell>(spellRequest);
        spell.Descriptors?.Clear();

        spell = await SetDescriptorForSpell(spell, spellRequest);
        return spell;
    }
    private async Task<Spell> SetDescriptorForSpell(Spell spell, SpellRequest spellRequest)
    {
        if (spellRequest.Descriptors is not null)
        {
            foreach (var descriptorName in spellRequest.Descriptors)
            {
                var descriptorEntity = await _context.Descriptor.FirstOrDefaultAsync(d => d.Name.ToLower() == descriptorName.ToLower());
                if (descriptorEntity is null)
                {
                    _logger.LogError("Couldn't find a descriptor matching {Name}", descriptorName);
                    continue;
                }
                spell.Descriptors?.Add(descriptorEntity);
            }
        }
        return spell;
    }

    /// <summary>
    ///     Remove a spell
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteSpell(int id)
    // {
    //     var spell = await _context.Spell.FindAsync(id);
    //     if (spell == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     _context.Spell.Remove(spell);
    //     await _context.SaveChangesAsync();
    //
    //     return NoContent();
    // }
    private bool SpellExists(int id)
    {
        return _context.Spell.Any(e => e.Id == id);
    }
}
