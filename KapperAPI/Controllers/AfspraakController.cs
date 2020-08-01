using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfspraakController : ControllerBase
    {
        private readonly KapperContext _context;

        public AfspraakController(KapperContext context)
        {
            _context = context;
        }

        // Get data from database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Afspraak>>> GetAfspraak()
        {
            return await _context.Afspraak.ToListAsync();
        }

        // Get data from database by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Afspraak>> GetAfspraak(int id)
        {
            var afspraak = await _context.Afspraak.FindAsync(id);

            if (afspraak == null)
            {
                return NotFound();
            }

            return afspraak;
        }

        // Update data from database
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAfspraak(int id, Afspraak afspraak)
        {
            if (id != afspraak.AfspraakID)
            {
                return BadRequest();
            }

            _context.Entry(afspraak).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AfspraakExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Add data from database
        [HttpPost]
        public async Task<ActionResult<Afspraak>> PostAfspraak([FromForm]Afspraak afspraak)
        {
            _context.Afspraak.Add(afspraak);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAfspraak", new { id = afspraak.AfspraakID }, afspraak);
        }

        // Delete data from database
        [HttpDelete("{id}")]
        public async Task<ActionResult<Afspraak>> DeleteAfspraak(int id)
        {
            var afspraak = await _context.Afspraak.FindAsync(id);
            if (afspraak == null)
            {
                return NotFound();
            }

            _context.Afspraak.Remove(afspraak);
            await _context.SaveChangesAsync();

            return afspraak;
        }

        private bool AfspraakExists(int id)
        {
            return _context.Afspraak.Any(e => e.AfspraakID == id);
        }
    }
}
