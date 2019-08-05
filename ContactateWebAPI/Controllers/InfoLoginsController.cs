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
    public class InfoLoginsController : ControllerBase
    {
        private readonly CONTACTATE_BDContext _context;

        public InfoLoginsController(CONTACTATE_BDContext context)
        {
            _context = context;
        }

        // GET: api/InfoLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoLogin>>> GetInfoLogin()
        {
            return await _context.InfoLogin.ToListAsync();
        }

        // GET: api/InfoLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoLogin>> GetInfoLogin(int id)
        {
            var infoLogin = await _context.InfoLogin.FindAsync(id);

            if (infoLogin == null)
            {
                return NotFound();
            }

            return infoLogin;
        }

        // PUT: api/InfoLogins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoLogin(int id, InfoLogin infoLogin)
        {
            if (id != infoLogin.IdInfoLogin)
            {
                return BadRequest();
            }

            _context.Entry(infoLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoLoginExists(id))
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

        // POST: api/InfoLogins
        [HttpPost]
        public async Task<ActionResult<InfoLogin>> PostInfoLogin(InfoLogin infoLogin)
        {
            _context.InfoLogin.Add(infoLogin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InfoLoginExists(infoLogin.IdInfoLogin))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInfoLogin", new { id = infoLogin.IdInfoLogin }, infoLogin);
        }

        // DELETE: api/InfoLogins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InfoLogin>> DeleteInfoLogin(int id)
        {
            var infoLogin = await _context.InfoLogin.FindAsync(id);
            if (infoLogin == null)
            {
                return NotFound();
            }

            _context.InfoLogin.Remove(infoLogin);
            await _context.SaveChangesAsync();

            return infoLogin;
        }

        private bool InfoLoginExists(int id)
        {
            return _context.InfoLogin.Any(e => e.IdInfoLogin == id);
        }
    }
}
