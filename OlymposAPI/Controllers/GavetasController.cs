
using HookBasicApp.Models.DB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OlymposAPI.DAL;
using OlymPOS.Models.DB;

namespace HookBasicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    //[EnableCors("PermitirConexion")]
    public class GavetasController : ControllerBase
    {
        private readonly ContextoDB _context;

        public GavetasController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/Gavetas
        [HttpGet]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<IEnumerable<Gavetas>>> GetGavetas(int sucursalID)
        {
            var res= await _context.Gavetas.Where(p => p.IsHabilitado && p.SucursalesID == sucursalID).ToListAsync();
            var gavetasDisponibles = new List<Gavetas>();
            foreach (var gaveta in res)
            {
                gaveta.LogGavetas = null;
                if ( _context.LogGavetas.Where(p => p.GavetasID == gaveta.ID).Count()>0)
                {
                    var ultimoRegistro = _context.LogGavetas.Where(p => p.GavetasID == gaveta.ID).ToList().Last();
                    gaveta.LogGavetas = null;
                    CierreDeGavetas cierreAsociado =await _context.CierreDeGaveta.FindAsync(ultimoRegistro.CierreDeGavetasID);
                    bool tieneCierreCiego = cierreAsociado != null;
                    if (ultimoRegistro.AperturaDeGavetasID ==null || (tieneCierreCiego)?(!cierreAsociado.IsCierreCiego) :(false))//== si tiene apertura o un cierre ciego
                    {
                        
                        gavetasDisponibles.Add(gaveta);
                    }
                }
                else
                {
                    gaveta.LogGavetas = null;
                    gavetasDisponibles.Add(gaveta);
                }
                
            }
            
            return gavetasDisponibles;
        }

   

        // PUT: api/Gavetas/5
        [HttpPut("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<IActionResult> PutGavetas(int id, Gavetas gavetas)
        {
            if (id != gavetas.ID)
            {
                return BadRequest();
            }

            _context.Entry(gavetas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GavetasExists(id))
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

        // POST: api/Gavetas
        [HttpPost]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Gavetas>> PostGavetas(Gavetas gavetas)
        {
            _context.Gavetas.Add(gavetas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGavetas", new { id = gavetas.ID }, gavetas);
        }

        // DELETE: api/Gavetas/5
        [HttpDelete("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Gavetas>> DeleteGavetas(int id)
        {
            var gavetas = await _context.Gavetas.FindAsync(id);
            if (gavetas == null)
            {
                return NotFound();
            }

            _context.Gavetas.Remove(gavetas);
            await _context.SaveChangesAsync();

            return gavetas;
        }

        private bool GavetasExists(int id)
        {
            return _context.Gavetas.Any(e => e.ID == id);
        }



    }
}
