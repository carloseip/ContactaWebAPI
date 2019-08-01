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
    public class AccesosController : ControllerBase
    {
        private readonly CONTACTATE_BDContext _context;

        public AccesosController(CONTACTATE_BDContext context)
        {
            _context = context;
        }

        // GET: api/Accesos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acceso>>> GetAcceso()
        {
            return await _context.Acceso.ToListAsync();
        }

        // GET: api/Accesos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acceso>> GetAcceso(int id)
        {
            var acceso = await _context.Acceso.FindAsync(id);

            if (acceso == null)
            {
                return NotFound();
            }

            return acceso;
        }

        // PUT: api/Accesos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcceso(int id, Acceso acceso)
        {
            if (id != acceso.IdAcceso)
            {
                return BadRequest();
            }

            _context.Entry(acceso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccesoExists(id))
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

        // POST: api/Accesos
        [HttpPost]
        public async Task<ActionResult<Acceso>> PostAcceso(Acceso acceso)
        {
            _context.Acceso.Add(acceso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcceso", new { id = acceso.IdAcceso }, acceso);
        }

        // POST: api/Accesos/login
        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> LoginUsuario(Acceso acceso)
        {
            var usuario = await _context.Acceso.FirstOrDefaultAsync(e => e.Correo.ToLower() == acceso.Correo.ToLower() && e.Contrasenia == acceso.Contrasenia);

            if (usuario == null)
            {
                //return NotFound();
                return BadRequest(new { mensaje = "Not", value = usuario });
            }

            return Ok(new { mensaje = "Ok", value = usuario });
        }

        // DELETE: api/Accesos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Acceso>> DeleteAcceso(int id)
        {
            var acceso = await _context.Acceso.FindAsync(id);
            if (acceso == null)
            {
                return NotFound();
            }

            _context.Acceso.Remove(acceso);
            await _context.SaveChangesAsync();

            return acceso;
        }

        private bool AccesoExists(int id)
        {
            return _context.Acceso.Any(e => e.IdAcceso == id);
        }
    }
}
