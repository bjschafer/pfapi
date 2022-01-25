#nullable disable
using api.Data;
using api.Models;

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
        var spells = await _context.Spell.Include(s => s.Descriptors)
                             .ToListAsync();
        return Ok(this._mapper!.Map<List<SpellResponse>>(spells));

    }

    // GET: api/Spell/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Spell>> GetSpell(int id)
    {
        var spell = await _context.Spell.FindAsync(id);

        if (spell == null)
        {
            return NotFound();
        }

        return Ok(spell);
    }

    // PUT: api/Spell/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
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
    public async Task<ActionResult<Spell>> PostSpell(Spell spell)
    {
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
