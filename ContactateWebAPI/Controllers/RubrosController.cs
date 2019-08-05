using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactateWebAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace ContactateWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Politica")]
    public class RubrosController : ControllerBase
    {
        private readonly CONTACTATE_BDContext _context;

        public RubrosController(CONTACTATE_BDContext context)
        {
            _context = context;
        }

        // GET: api/Rubros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rubro>>> GetRubro()
        {
            return await _context.Rubro.ToListAsync();
        }

        // GET: api/Rubros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rubro>> GetRubro(int id)
        {
            var rubro = await _context.Rubro.FindAsync(id);

            if (rubro == null)
            {
                return NotFound();
            }

            return rubro;
        }

        // PUT: api/Rubros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRubro(int id, Rubro rubro)
        {
            if (id != rubro.IdRubro)
            {
                return BadRequest();
            }

            _context.Entry(rubro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RubroExists(id))
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

        // POST: api/Rubros
        [HttpPost]
        public async Task<ActionResult<Rubro>> PostRubro(Rubro rubro)
        {
            _context.Rubro.Add(rubro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRubro", new { id = rubro.IdRubro }, rubro);
        }

        // DELETE: api/Rubros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rubro>> DeleteRubro(int id)
        {
            var rubro = await _context.Rubro.FindAsync(id);
            if (rubro == null)
            {
                return NotFound();
            }

            _context.Rubro.Remove(rubro);
            await _context.SaveChangesAsync();

            return rubro;
        }

        private bool RubroExists(int id)
        {
            return _context.Rubro.Any(e => e.IdRubro == id);
        }
    }
}
