using api.Data;
using api.Models.Database;
using api.Models.Request;
using api.Utils;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class AdminController(ApiContext context, IMapper mapper, ILogger<AdminController> logger) : ControllerBase
{
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
        var existingSpell = await context.Spell.FindAsync(id);
        if (existingSpell is null)
        {
            return NotFound();
        }
        var spell = mapper.Map(spellRequest, existingSpell);

        context.Entry(spell!).State = EntityState.Modified;
        await context.SaveChangesAsync();
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

        context.Spell.Add(spell);

        await context.SaveChangesAsync();

        return CreatedAtRoute(new
        {
            id = spell.Id,
        }, spellRequest);
    }
    private async Task<Spell> mapSpellRequestToSpell(SpellRequest spellRequest)
    {
        var spell = mapper.Map<Spell>(spellRequest);
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
                var descriptorEntity = await context.Descriptor.FirstOrDefaultAsync(d => d.Name == descriptorName.ToTitleCase());
                if (descriptorEntity is null)
                {
                    logger.LogError("Couldn't find a descriptor matching {Name}", descriptorName);
                    continue;
                }
                spell.Descriptors?.Add(descriptorEntity);
            }
        }
        return spell;
    }
}
