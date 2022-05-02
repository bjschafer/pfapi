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

    /// <summary>
    ///     Find spells
    /// </summary>
    /// <returns>A JSON list containing all spells in the database</returns>
    /// <param name="spellName">Optional partial spell name to filter by</param>
    /// <param name="className">Optional class to filter by</param>
    /// <param name="level">Optional spell level to filter by</param>
    /// <param name="school">Optional school name to filter by</param>
    /// <param name="page">Page number of results to get</param>
    /// <param name="limit">Number of results to return (max 100)</param>
    /// <response code="200">Returns up to limit spells</response>
    /// <response code="400">Error validating parameters -- keep limit below 100</response>
    [HttpGet]
    public async Task<ActionResult<List<SpellResponse>>> FindSpells(string? spellName, string? className, int? level, string? school, int page = 1, int limit = 20)
    {
        var validPagination = Misc.ValidatePagination(page, limit);
        if (validPagination is not null)
        {
            return BadRequest(validPagination);
        }

        var desiredClass = await validateClass(className);
        if (desiredClass is null && className is not null)
        {
            return NotFound($"Class {className} not found");
        }
        var spells = await _context.Spell
                                   .WhereIf(desiredClass is not null && level.HasValue, s => s.ClassLevels.Any(cl => cl.ClassName == className!.ToTitleCase() && cl.Level == level))
                                   .WhereIf(desiredClass is not null, s => s.ClassLevels.Any(cl => cl.ClassName == className!.ToTitleCase()))
                                   .WhereIf(level.HasValue, s => s.ClassLevels.Any(cl => cl.Level == level))
                                   .WhereIf(school is not null, s => s.School == school!.ToTitleCase())
                                   .WhereIf(spellName is not null, s => s.Name.Contains(spellName!, StringComparison.CurrentCultureIgnoreCase))
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
                                  .FirstOrDefaultAsync(s => s.Name == name.ToTitleCase());

        if (spell is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SpellResponse>(spell));
    }

    private async Task<Class?> validateClass(string? className)
    {
        if (className is not null)
        {
            return await _context.Class
                                 .FirstOrDefaultAsync(c => c.Name == className.ToTitleCase());
        }
        return null!;
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
        var validPagination = Misc.ValidatePagination(page, limit);
        if (validPagination is not null)
        {
            return BadRequest(validPagination);
        }
        var desiredClass = await _context.Class
                                         .FirstOrDefaultAsync(c => c.Name == className.ToTitleCase());
        if (desiredClass is null)
        {
            return NotFound($"Class {className} not found");
        }

        var spells = await _context.Spell
                                   .Include(s => s.Descriptors)
                                   .Include(s => s.Source)
                                   .WhereIf(level is not null, s => s.ClassLevels.Any(cl => cl.ClassName == desiredClass.Name && cl.Level == level))
                                   .Where(s => s.ClassLevels.Any(cl => cl.ClassName == desiredClass.Name))
                                   .Skip((page - 1) * limit)
                                   .Take(limit)
                                   .ToListAsync();
        var mappedSpells = _mapper.Map<List<SpellResponse>>(spells);
        return Ok(mappedSpells);
    }
}
