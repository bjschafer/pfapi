#nullable disable
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
    private readonly ApiContext _context;
    private readonly IMapper    _mapper;

    public SpellController(ApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper  = mapper;
    }

    // GET: api/Spell
    [HttpGet]
    public async Task<ActionResult<List<SpellResponse>>> GetSpell()
    {
        var spells = await _context.Spell
                                   .Include(s => s.Descriptors)
                                   .Include(s => s.Source)
                                   .Include(s => s.ClassSpells)
                                   .ThenInclude(cs => cs.Class)
                                   .ToListAsync();
        return Ok(_mapper!.Map<List<SpellResponse>>(spells));
    }

    // GET: api/Spell/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<SpellResponse>> GetSpell(int id)
    {
        var spell = await _context.Spell
                                  .Include(s => s.Descriptors)
                                  .Include(s => s.Source)
                                  .Include(s => s.ClassSpells)
                                  .ThenInclude(cs => cs.Class)
                                  .FirstOrDefaultAsync(s => s.Id == id);

        if (spell == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SpellResponse>(spell));
    }

    // GET: api/Spell/Class/Wizard
    [HttpGet("Class/{className}")]
    public async Task<ActionResult<List<SpellResponse>>> GetSpellsByClass(string className)
    {
        var desiredClass = await _context.Class
                                         .FirstOrDefaultAsync(c => c.Name == className);
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
        return Ok(_mapper.Map<List<SpellResponse>>(spells));
    }

    // PUT: api/Spell/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutSpell(int id, Spell spell)
    {
        if (id != spell.Id)
        {
            return BadRequest();
        }

        _context.Entry(spell).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SpellExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // POST: api/Spell
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Spell>> PostSpell(SpellRequest spellRequest)
    {
        var spell = _mapper.Map<Spell>(spellRequest);
        _context.Spell.Add(spell);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSpell", new
        {
            id = spell.Id,
        }, spell);
    }

    // DELETE: api/Spell/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpell(int id)
    {
        var spell = await _context.Spell.FindAsync(id);
        if (spell == null)
        {
            return NotFound();
        }

        _context.Spell.Remove(spell);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SpellExists(int id)
    {
        return _context.Spell.Any(e => e.Id == id);
    }
}
