#nullable disable
using api.Data;
using api.Models.Response;
using api.Utils;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassController(ApiContext context, IMapper mapper, ILogger<ClassController> logger) : ControllerBase
{
    /// <summary>
    /// List all classes in the database
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClassResponse>>> GetClass()
    {
        return Ok(mapper.Map<IEnumerable<ClassResponse>>(await context.Class.ToListAsync()));
    }

    /// <summary>
    /// Get all info on a particular class
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <response code="200" />
    /// <response code="400" />
    [HttpGet("{name}")]
    public async Task<ActionResult<ClassResponse>> GetClass(string name)
    {
        var @class = await context.Class.FirstOrDefaultAsync(c => c.Name == name.ToTitleCase());

        if (@class is null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<ClassResponse>(@class));
    }

    /// <summary>
    /// Calculate number of spells per day a character receives
    /// given their class, level of spell, and their corresponding
    /// ability score
    /// </summary>
    /// <param name="name">Class name</param>
    /// <param name="classLevel">The class level to calculate for</param>
    /// <param name="spellLevel">The level of spell to calculate for</param>
    /// <param name="abilityScore">Spellcasting ability score (NOT modifier)</param>
    /// <returns></returns>
    /// <response code="200" />
    /// <response code="404" />
    [HttpGet("{name}/SpellsPerDay")]
    public async Task<ActionResult<int>> GetSpellsPerDay(string name, int classLevel, int spellLevel, int abilityScore)
    {
        var @class = await context.Class.FirstOrDefaultAsync(c => c.Name == name.ToTitleCase());

        if (@class is null)
        {
            return NotFound();
        }

        return Tables.GetBonusSpells(spellLevel, abilityScore) + @class.SpellsPerDay?[classLevel][spellLevel];
    }

    /// <summary>
    /// Find the highest-level spell that a character of the given class and level can cast
    /// </summary>
    /// <param name="name">Class name -- e.g. Wizard</param>
    /// <param name="classLevel">Current class level</param>
    /// <returns>The highest level spell that can be cast</returns>
    /// <response code="200" />
    /// <response code="404" />
    [HttpGet("{name}/HighestSpellLevel")]
    public async Task<ActionResult<int>> GetHighestSpellLevel(string name, int classLevel)
    {
        var @class = await context.Class.FirstOrDefaultAsync(c => c.Name == name.ToTitleCase());
        if (@class is null)
        {
            return NotFound();
        }

        return Ok(@class.MaxSpellLevel(classLevel));
    }
}
