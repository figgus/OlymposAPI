using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HookBasicApp.Models.DB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using OlymposAPI.DAL;

namespace HookBasicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    //[EnableCors("PermitirConexion")]
    public class GruposController : ControllerBase
    {
        private readonly ContextoDB _context;

        public GruposController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/Grupos
        [HttpGet]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<IEnumerable<Grupos>>> GetGrupos()
        {
            return await _context.Grupos.ToListAsync();
        }

        // GET: api/Grupos/5
        [HttpGet("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Grupos>> GetGrupos(int id)
        {
            var grupos = await _context.Grupos.FindAsync(id);

            if (grupos == null)
            {
                return NotFound();
            }

            return grupos;
        }

        // PUT: api/Grupos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<IActionResult> PutGrupos(int id, Grupos grupos)
        {
            if (id != grupos.ID)
            {
                return BadRequest();
            }

            _context.Entry(grupos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GruposExists(id))
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

        // POST: api/Grupos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Grupos>> PostGrupos(Grupos grupos)
        {
            _context.Grupos.Add(grupos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupos", new { id = grupos.ID }, grupos);
        }

        // DELETE: api/Grupos/5
        [HttpDelete("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Grupos>> DeleteGrupos(int id)
        {
            var grupos = await _context.Grupos.FindAsync(id);
            if (grupos == null)
            {
                return NotFound();
            }

            _context.Grupos.Remove(grupos);
            await _context.SaveChangesAsync();

            return grupos;
        }

        private bool GruposExists(int id)
        {
            return _context.Grupos.Any(e => e.ID == id);
        }
    }
}
