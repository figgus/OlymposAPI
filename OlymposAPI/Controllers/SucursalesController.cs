using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlymposAPI.DAL;
using HookBasicApp.Models.DB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace HookBasicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("PermitirConexion")]
    public class SucursalesController : ControllerBase
    {
        private readonly ContextoDB _context;

        public SucursalesController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/Sucursales
        [HttpGet]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<IEnumerable<Sucursales>>> GetSucursales()
        {
            return await _context.Sucursales.ToListAsync();
        }

        // GET: api/Sucursales/5
        [HttpGet("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Sucursales>> GetSucursales(string id)
        {
            var sucursales = await _context.Sucursales.FindAsync(id);

            if (sucursales == null)
            {
                return NotFound();
            }

            return sucursales;
        }

        // PUT: api/Sucursales/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<IActionResult> PutSucursales(int id, Sucursales sucursales)
        {
            if (id != sucursales.ID)
            {
                return BadRequest();
            }

            _context.Entry(sucursales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalesExists(id))
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

        // POST: api/Sucursales
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Sucursales>> PostSucursales(Sucursales sucursales)
        {
            _context.Sucursales.Add(sucursales);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SucursalesExists(sucursales.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSucursales", new { id = sucursales.ID }, sucursales);
        }

        // DELETE: api/Sucursales/5
        [HttpDelete("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Sucursales>> DeleteSucursales(string id)
        {
            var sucursales = await _context.Sucursales.FindAsync(id);
            if (sucursales == null)
            {
                return NotFound();
            }

            _context.Sucursales.Remove(sucursales);
            await _context.SaveChangesAsync();

            return sucursales;
        }

        private bool SucursalesExists(int id)
        {
            return _context.Sucursales.Any(e => e.ID == id);
        }
    }
}
