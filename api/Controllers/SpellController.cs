#nullable disable
using api.Data;
using api.Models.Database;
using api.Models.Request;
using api.Models.Response;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpellController : ControllerBase
{
    private readonly ApiContext               _context;
    private readonly IMapper                  _mapper;
    private readonly ILogger<SpellController> _logger;

    public SpellController(ApiContext context, IMapper mapper, ILogger<SpellController> logger)
    {
        _context = context;
        _mapper  = mapper;
        _logger  = logger;
    }

    /// <summary>
    /// Get all spells
    /// </summary>
    /// <returns>A JSON list containing all spells in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<SpellResponse>>> GetSpell()
    {
        var spells = await _context.Spell
                                   .Include(s => s.Descriptors)
                                   .Include(s => s.Source)
                                   .Include(s => s.ClassSpells)
                                   .ThenInclude(cs => cs.Class)
                                   .ToListAsync();
        var mappedSpells = _mapper.Map<List<SpellResponse>>(spells);
        return Ok(mappedSpells);
    }

    /// <summary>
    /// Get a spell with a specific ID
    /// </summary>
    /// <param name="name">The spell's exact name</param>
    /// <returns>A JSON object representing the given spell, if it exists</returns>
    /// <remarks>
    /// This is probably only useful if you've stored the ID in your client app
    /// and want to quickly fetch data on the spell
    /// </remarks>
    /// <response code="200">Returns the spell</response>
    /// <response code="404">Spell with given ID not found</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SpellResponse>> GetSpell(string name)
    {
        var spell = await _context.Spell
                                  .Include(s => s.Descriptors)
                                  .Include(s => s.Source)
                                  .Include(s => s.ClassSpells)
                                  .ThenInclude(cs => cs.Class)
                                  .FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());

        if (spell == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SpellResponse>(spell));
    }

    /// <summary>
    /// Get all spells on a given class list
    /// </summary>
    /// <param name="className">Class to search for, e.g. Wizard</param>
    /// <returns>Spells that class can cast</returns>
    /// <response code="200">Returns all requested spells</response>
    /// <response code="404">The class you specified wasn't found</response>
    [HttpGet("Class/{className}")]
    public async Task<ActionResult<List<SpellResponse>>> GetSpellsByClass(string className)
    {
        var desiredClass = await _context.Class
                                         .FirstOrDefaultAsync(c => c.Name.ToLower() == className.ToLower());
        if (desiredClass is null)
        {
            return NotFound($"Class {className} not found");
        }

        var spells = await _context.Spell
                                   .Include(s => s.Descriptors)
                                   .Include(s => s.Source)
                                   .Include(s => s.ClassSpells)
                                   .ThenInclude(cs => cs.Class)
                                   .Where(s => s.Classes.Contains(desiredClass))
                                   .ToListAsync();
        var mappedSpells = _mapper.Map<List<SpellResponse>>(spells);
        return Ok(mappedSpells);
    }

    /// <summary>
    /// Update a spell
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
    /// Create a new spell
    /// </summary>
    /// <param name="spellRequest"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Spell>> PostSpell([FromBody] SpellRequest spellRequest)
    {
        var spell = await MapSpellRequestToSpell(spellRequest);

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
        spell.ClassSpells.Clear();
        spell.Descriptors?.Clear();

        spell = await SetDescriptorForSpell(spell, spellRequest);
        spell = await SetClassForSpell(spell, spellRequest);
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
    private async Task<Spell> SetClassForSpell(Spell spell, SpellRequest spellRequest)
    {

        foreach (var classLevel in spellRequest.ClassSpells.Select(cs => new KeyValuePair<string, int>(cs.ClassName, cs.Level)))
        {
            var classEntity = await _context.Class.FirstOrDefaultAsync(c => c.Name == classLevel.Key);
            if (classEntity is null)
            {
                _logger.LogError("Couldn't find a class for {Class}", classLevel.Key);
                continue;
            }
            var classSpell = new ClassSpell()
            {
                Class   = classEntity,
                ClassId = classEntity.Id,
                Level   = classLevel.Value,
            };
            spell.ClassSpells.Add(classSpell);
        }
        return spell;
    }

    /// <summary>
    /// Remove a spell
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
