#nullable disable
using api.Data;
using api.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpellController : ControllerBase
{
    private readonly ApiContext _context;

    public SpellController(ApiContext context)
    {
        _context = context;
    }

    // GET: api/Spell
    [HttpGet]
    public async Task<ActionResult<List<Spell>>> GetSpell()
    {
        return await _context.Spell
                             .Include(s => s.Descriptors)
                             .Include(s => s.ClassLevels)
                             .ToListAsync();
    }

    // GET: api/Spell/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Spell>> GetSpell(int id)
    {
        var spell = await _context.Spell
                                  .Include(s => s.Descriptors)
                                  .Include(s => s.ClassLevels)
                                  .FirstOrDefaultAsync(s => s.Id == id);

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
        List<Descriptor> existingDescriptors = new();
        if (spell.Descriptors is not null)
        {
            foreach (var descriptor in spell.Descriptors)
            {
                var existing = await _context.Descriptor.FirstOrDefaultAsync(d => d.Name == descriptor.Name);
                existingDescriptors.Add(existing ?? descriptor);
            }

            spell.Descriptors = existingDescriptors;
        }
        
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
