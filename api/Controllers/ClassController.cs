#nullable disable
using api.Data;
using api.Models.Database;
using api.Utils;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassController : ControllerBase
{
    private readonly ApiContext               _context;
    private readonly ILogger<ClassController> _logger;
    private readonly IMapper                  _mapper;

    public ClassController(ApiContext context, IMapper mapper, ILogger<ClassController> logger)
    {
        _context = context;
        _mapper  = mapper;
        _logger  = logger;
    }

    // GET: api/Class
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Class>>> GetClass()
    {
        return await _context.Class.ToListAsync();
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<Class>> GetClass(string name)
    {
        var @class = await _context.Class.FirstOrDefaultAsync(c => string.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (@class is null)
        {
            return NotFound();
        }

        return @class;
    }

    [HttpGet("{name}/SpellsPerDay")]
    public async Task<ActionResult<int>> GetSpellsPerDay(string name, int classLevel, int spellLevel, int abilityScore)
    {
        var @class = await _context.Class.FirstOrDefaultAsync(c => string.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (@class is null)
        {
            return NotFound();
        }

        return Tables.GetBonusSpells(spellLevel, abilityScore) + @class.SpellsPerDay?[classLevel][spellLevel];
    }
}
