using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlymposAPI.DAL;
using HookBasicApp.Models.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;

namespace HookBasicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    //[EnableCors("PermitirConexion")]
    public class MediosDePagoController : ControllerBase
    {
        private readonly ContextoDB _context;

        public MediosDePagoController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/MediosDePago
        [HttpGet]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<IEnumerable<MediosDePago>>> GetMediosDePago()
        {
            return await _context.MediosDePago.Where(p=>p.IsHabilitado).ToListAsync();
        }

        // GET: api/MediosDePago/5
        [HttpGet("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<MediosDePago>> GetMediosDePago(int id)
        {
            var mediosDePago = await _context.MediosDePago.FindAsync(id);

            if (mediosDePago == null)
            {
                return NotFound();
            }

            return mediosDePago;
        }

        // PUT: api/MediosDePago/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<IActionResult> PutMediosDePago(int id, MediosDePago mediosDePago)
        {
            if (id != mediosDePago.ID)
            {
                return BadRequest();
            }

            _context.Entry(mediosDePago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediosDePagoExists(id))
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

        // POST: api/MediosDePago
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<MediosDePago>> PostMediosDePago(MediosDePago mediosDePago)
        {
            _context.MediosDePago.Add(mediosDePago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediosDePago", new { id = mediosDePago.ID }, mediosDePago);
        }

        // DELETE: api/MediosDePago/5
        [HttpDelete("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<MediosDePago>> DeleteMediosDePago(int id)
        {
            var mediosDePago = await _context.MediosDePago.FindAsync(id);
            if (mediosDePago == null)
            {
                return NotFound();
            }

            _context.MediosDePago.Remove(mediosDePago);
            await _context.SaveChangesAsync();

            return mediosDePago;
        }

        private bool MediosDePagoExists(int id)
        {
            return _context.MediosDePago.Any(e => e.ID == id);
        }
    }
}
