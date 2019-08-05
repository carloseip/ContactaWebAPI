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
    public class TarjetasPresentacionController : ControllerBase
    {
        private readonly CONTACTATE_BDContext _context;

        public TarjetasPresentacionController(CONTACTATE_BDContext context)
        {
            _context = context;
        }

        // GET: api/TarjetasPresentacion
        [HttpGet]
        public async Task<ActionResult> GetTarjetasPresentacion()
        {
            var query = await _context.TarjetaPresentacion.Join(_context.Usuario, t => t.IdUsuario, u => u.IdUsuario,
                (t, u) => new
                {
                    idTarjeta = t.IdTarjeta,
                    usuario = $"{u.Nombres} {u.ApellidoPaterno} {u.ApellidoMaterno}",
                    cargo = t.Ocupacion,
                    especialidad = t.Especialidad,
                    telefono = t.Telefono,
                    correo = t.Correo,
                    direccion = u.Direccion,
                    imagen = t.Imagen
                }).ToListAsync();

            return Ok(new { mensaje = "correcto", value = query });
        }

        // GET: api/TarjetasPresentacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarjetaPresentacion>> GetTarjetaPresentacion(int id)
        {
            //var tarjetaPresentacion = await _context.TarjetaPresentacion.FindAsync(id);

            var query = await _context.TarjetaPresentacion.Join(_context.Usuario, t => t.IdUsuario, u => u.IdUsuario,
                (t, u) => new
                {
                    idTarjeta = t.IdTarjeta,
                    usuario = $"{u.Nombres} {u.ApellidoPaterno} {u.ApellidoMaterno}",
                    cargo = t.Ocupacion,
                    especialidad = t.Especialidad,
                    telefono = t.Telefono,
                    correo = t.Correo,
                    direccion = u.Direccion
                }).Where(eval => eval.idTarjeta == id).FirstOrDefaultAsync();

            if (query == null)
            {
                return NotFound();
            }

            return Ok(new { mensaje = "correcto", value = query });
        }

        // PUT: api/TarjetasPresentacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarjetaPresentacion(int id, TarjetaPresentacion tarjetaPresentacion)
        {
            if (id != tarjetaPresentacion.IdTarjeta)
            {
                return BadRequest();
            }

            _context.Entry(tarjetaPresentacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarjetaPresentacionExists(id))
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

        // POST: api/TarjetasPresentacion
        [HttpPost]
        public async Task<ActionResult<TarjetaPresentacion>> PostTarjetaPresentacion(TarjetaPresentacion tarjetaPresentacion)
        {
            _context.TarjetaPresentacion.Add(tarjetaPresentacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarjetaPresentacion", new { id = tarjetaPresentacion.IdTarjeta }, tarjetaPresentacion);
        }

        // DELETE: api/TarjetasPresentacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarjetaPresentacion>> DeleteTarjetaPresentacion(int id)
        {
            var tarjetaPresentacion = await _context.TarjetaPresentacion.FindAsync(id);
            if (tarjetaPresentacion == null)
            {
                return NotFound();
            }

            _context.TarjetaPresentacion.Remove(tarjetaPresentacion);
            await _context.SaveChangesAsync();

            return tarjetaPresentacion;
        }

        private bool TarjetaPresentacionExists(int id)
        {
            return _context.TarjetaPresentacion.Any(e => e.IdTarjeta == id);
        }
    }
}
