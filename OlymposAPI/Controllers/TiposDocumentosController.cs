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
    [Authorize(AuthenticationSchemes = "Bearer")]
    //[EnableCors("PermitirConexion")]
    public class TiposDocumentosController : ControllerBase
    {
        private readonly ContextoDB _context;

        public TiposDocumentosController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/TiposDocumentos
        [HttpGet]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<IEnumerable<TiposDocumento>>> GetTiposDocumento()
        {
            return await _context.TiposDocumento.Where(p=>p.IsHabilitado).ToListAsync();
        }

        // GET: api/TiposDocumentos/5
        [HttpGet("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<TiposDocumento>> GetTiposDocumento(int id)
        {
            var tiposDocumento = await _context.TiposDocumento.FindAsync(id);

            if (tiposDocumento == null)
            {
                return NotFound();
            }

            return tiposDocumento;
        }

        // PUT: api/TiposDocumentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<IActionResult> PutTiposDocumento(int id, TiposDocumento tiposDocumento)
        {
            if (id != tiposDocumento.ID)
            {
                return BadRequest();
            }

            _context.Entry(tiposDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposDocumentoExists(id))
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

        // POST: api/TiposDocumentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<TiposDocumento>> PostTiposDocumento(TiposDocumento tiposDocumento)
        {
            _context.TiposDocumento.Add(tiposDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposDocumento", new { id = tiposDocumento.ID }, tiposDocumento);
        }

        // DELETE: api/TiposDocumentos/5
        [HttpDelete("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<TiposDocumento>> DeleteTiposDocumento(int id)
        {
            var tiposDocumento = await _context.TiposDocumento.FindAsync(id);
            if (tiposDocumento == null)
            {
                return NotFound();
            }

            _context.TiposDocumento.Remove(tiposDocumento);
            await _context.SaveChangesAsync();

            return tiposDocumento;
        }

        private bool TiposDocumentoExists(int id)
        {
            return _context.TiposDocumento.Any(e => e.ID == id);
        }
    }
}
