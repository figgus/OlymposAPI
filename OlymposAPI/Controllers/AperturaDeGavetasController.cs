using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HookBasicApp.Models.DB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

using OlymposAPI.DAL;

namespace OlymPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    //[EnableCors("PermitirConexion")]
    public class AperturaDeGavetasController : ControllerBase
    {
        private readonly ContextoDB _context;

        public AperturaDeGavetasController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/AperturaDeGavetas
        [HttpGet]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<IEnumerable<AperturaDeGavetas>>> GetAperturaDeGavetas()
        {
            return await _context.AperturaDeGavetas.ToListAsync();
        }

        // GET: api/AperturaDeGavetas/5
        [HttpGet("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<AperturaDeGavetas>> GetAperturaDeGavetas(int id)
        {
            var aperturaDeGavetas = await _context.AperturaDeGavetas.FindAsync(id);

            if (aperturaDeGavetas == null)
            {
                return NotFound();
            }

            return aperturaDeGavetas;
        }

        // PUT: api/AperturaDeGavetas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<IActionResult> PutAperturaDeGavetas(int id, AperturaDeGavetas aperturaDeGavetas)
        {
            if (id != aperturaDeGavetas.ID)
            {
                return BadRequest();
            }

            _context.Entry(aperturaDeGavetas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AperturaDeGavetasExists(id))
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

        // POST: api/AperturaDeGavetas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<AperturaDeGavetas>> PostAperturaDeGavetas(AperturaDeGavetas aperturaDeGavetas)
        {
            aperturaDeGavetas.FechaDeApertura = DateTime.Now;
            _context.AperturaDeGavetas.Add(aperturaDeGavetas);
            await _context.SaveChangesAsync();
            LogGavetas nuevoRegistro = new LogGavetas
            {
                AperturaDeGavetasID = aperturaDeGavetas.ID,
                Descripcion = "Gaveta abierta",
                Fecha = DateTime.Now,
                GavetasID = aperturaDeGavetas.GavetasID,
                Modulo = "apertura"
            };
            _context.LogGavetas.Add(nuevoRegistro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAperturaDeGavetas", new { id = aperturaDeGavetas.ID }, aperturaDeGavetas);
        }
        

        // DELETE: api/AperturaDeGavetas/5
        [HttpDelete("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<AperturaDeGavetas>> DeleteAperturaDeGavetas(int id)
        {
            var aperturaDeGavetas = await _context.AperturaDeGavetas.FindAsync(id);
            if (aperturaDeGavetas == null)
            {
                return NotFound();
            }

            _context.AperturaDeGavetas.Remove(aperturaDeGavetas);
            await _context.SaveChangesAsync();

            return aperturaDeGavetas;
        }

        private bool AperturaDeGavetasExists(int id)
        {
            return _context.AperturaDeGavetas.Any(e => e.ID == id);
        }

        [HttpGet("GetAperturasPendientes")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<IEnumerable<AperturaDeGavetas>>> GetAperturasPendientes(int sucursalID)
        {
            var res = await _context.AperturaDeGavetas.Include(p=>p.CierreDeGaveta)
                .Include(p=>p.Usuario)
                .Include(p=>p.Gaveta)
                .Include(p=>p.CierreDeGaveta).ThenInclude(p=>p.MediosPorCierre)
                .Where(p => p.SucursalesID == sucursalID && (p.CierreDeGavetasID==null || (p.CierreDeGaveta.IsCierreCiego && !p.CierreDeGaveta.IsCerrada))).ToListAsync();
            
            return res;
        }

        [HttpGet("GetAperturaActual")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<AperturaDeGavetas>> GetAperturaActual(int estacionesID)
        {
            var res = await _context.AperturaDeGavetas.Include(p => p.CierreDeGaveta)
                .Include(p => p.Usuario)
                .Include(p => p.Gaveta)
                .FirstOrDefaultAsync(p =>p.Usuario.EstacionesID == estacionesID && p.CierreDeGavetasID==null);


            return res;
        }


    }


}

