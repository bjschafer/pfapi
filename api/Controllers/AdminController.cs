using api.Data;
using api.Models.Database;
using api.Models.Request;
using api.Models.Response;
using api.Utils;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class AdminController : ControllerBase
{
    private readonly ApiContext               _context;
    private readonly ILogger<AdminController> _logger;
    private readonly IMapper                  _mapper;

    public AdminController(ApiContext context, IMapper mapper, ILogger<AdminController> logger)
    {
        _context = context;
        _mapper  = mapper;
        _logger  = logger;
    }

    /// <summary>
    ///     Update a spell
    /// </summary>
    /// <param name="id"></param>
    /// <param name="spellRequest"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    [Authorize]
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
        var spell = await mapSpellRequestToSpell(spellRequest);
        // TODO validate classes contained are valid

        _context.Spell.Add(spell);

        await _context.SaveChangesAsync();

        return CreatedAtRoute(new
        {
            id = spell.Id,
        }, spellRequest);
    }
    private async Task<Spell> mapSpellRequestToSpell(SpellRequest spellRequest)
    {
        var spell = _mapper.Map<Spell>(spellRequest);
        spell.Descriptors?.Clear();

        spell = await setDescriptorForSpell(spell, spellRequest);
        return spell;
    }
    private async Task<Spell> setDescriptorForSpell(Spell spell, SpellRequest spellRequest)
    {
        if (spellRequest.Descriptors is not null)
        {
            foreach (var descriptorName in spellRequest.Descriptors)
            {
                var descriptorEntity = await _context.Descriptor.FirstOrDefaultAsync(d => d.Name == descriptorName.ToTitleCase());
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
}
