using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlymPOS.Models.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using OlymposAPI.DAL;

namespace OlymPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("PermitirConexion")]
    public class DescuentosController : ControllerBase
    {
        private readonly ContextoDB _context;

        public DescuentosController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/Descuentos
        [HttpGet]
        [EnableCors("PermitirConexion")]
        //[Authorize]

        public async Task<ActionResult<IEnumerable<Descuentos>>> GetDescuentos()
        {
            return await _context.Descuentos.ToListAsync();
        }

        // GET: api/Descuentos/5
        [HttpGet("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Descuentos>> GetDescuentos(int id)
        {
            var descuentos = await _context.Descuentos.FindAsync(id);

            if (descuentos == null)
            {
                return NotFound();
            }

            return descuentos;
        }

        // PUT: api/Descuentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<IActionResult> PutDescuentos(int id, Descuentos descuentos)
        {
            if (id != descuentos.ID)
            {
                return BadRequest();
            }

            _context.Entry(descuentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescuentosExists(id))
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

        // POST: api/Descuentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Descuentos>> PostDescuentos(Descuentos descuentos)
        {
            _context.Descuentos.Add(descuentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDescuentos", new { id = descuentos.ID }, descuentos);
        }

        // DELETE: api/Descuentos/5
        [HttpDelete("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Descuentos>> DeleteDescuentos(int id)
        {
            var descuentos = await _context.Descuentos.FindAsync(id);
            if (descuentos == null)
            {
                return NotFound();
            }

            _context.Descuentos.Remove(descuentos);
            await _context.SaveChangesAsync();

            return descuentos;
        }

        private bool DescuentosExists(int id)
        {
            return _context.Descuentos.Any(e => e.ID == id);
        }
    }
}
