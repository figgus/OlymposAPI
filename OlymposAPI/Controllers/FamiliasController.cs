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

namespace OlymPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("PermitirConexion")]
    public class FamiliasController : ControllerBase
    {
        private readonly ContextoDB _context;

        public FamiliasController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/Familias
        [HttpGet]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<IEnumerable<Familias>>> GetFamilias()
        {
            return await _context.Familias.ToListAsync();
        }

        // GET: api/Familias/5
        [HttpGet("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Familias>> GetFamilias(int id)
        {
            var familias = await _context.Familias.FindAsync(id);

            if (familias == null)
            {
                return NotFound();
            }

            return familias;
        }

        // PUT: api/Familias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<IActionResult> PutFamilias(int id, Familias familias)
        {
            if (id != familias.ID)
            {
                return BadRequest();
            }

            _context.Entry(familias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamiliasExists(id))
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

        // POST: api/Familias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Familias>> PostFamilias(Familias familias)
        {
            _context.Familias.Add(familias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamilias", new { id = familias.ID }, familias);
        }

        // DELETE: api/Familias/5
        [HttpDelete("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Familias>> DeleteFamilias(int id)
        {
            var familias = await _context.Familias.FindAsync(id);
            if (familias == null)
            {
                return NotFound();
            }

            _context.Familias.Remove(familias);
            await _context.SaveChangesAsync();

            return familias;
        }

        private bool FamiliasExists(int id)
        {
            return _context.Familias.Any(e => e.ID == id);
        }
    }
}
