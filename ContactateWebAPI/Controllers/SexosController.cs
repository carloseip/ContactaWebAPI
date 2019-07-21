using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactateWebAPI.Models;

namespace ContactateWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexosController : ControllerBase
    {
        private readonly CONTACTATE_BDContext _context;

        public SexosController(CONTACTATE_BDContext context)
        {
            _context = context;
        }

        // GET: api/Sexos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sexo>>> GetSexo()
        {
            return await _context.Sexo.ToListAsync();
        }

        // GET: api/Sexos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sexo>> GetSexo(int id)
        {
            var sexo = await _context.Sexo.FindAsync(id);

            if (sexo == null)
            {
                return NotFound();
            }

            return sexo;
        }

        // PUT: api/Sexos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSexo(int id, Sexo sexo)
        {
            if (id != sexo.IdSexo)
            {
                return BadRequest();
            }

            _context.Entry(sexo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SexoExists(id))
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

        // POST: api/Sexos
        [HttpPost]
        public async Task<ActionResult<Sexo>> PostSexo(Sexo sexo)
        {
            _context.Sexo.Add(sexo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSexo", new { id = sexo.IdSexo }, sexo);
        }

        // DELETE: api/Sexos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sexo>> DeleteSexo(int id)
        {
            var sexo = await _context.Sexo.FindAsync(id);
            if (sexo == null)
            {
                return NotFound();
            }

            _context.Sexo.Remove(sexo);
            await _context.SaveChangesAsync();

            return sexo;
        }

        private bool SexoExists(int id)
        {
            return _context.Sexo.Any(e => e.IdSexo == id);
        }
    }
}
