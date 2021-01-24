using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HookBasicApp.Models.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlymPOS.Models.DB;
using OlymposAPI.DAL;

namespace OlymposAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CierreDeGavetasController : ControllerBase
    {
        private readonly ContextoDB _context;

        public CierreDeGavetasController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/CierreDeGavetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CierreDeGavetas>>> GetCierreDeGaveta()
        {
            return await _context.CierreDeGaveta.ToListAsync();
        }

        // GET: api/CierreDeGavetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CierreDeGavetas>> GetCierreDeGavetas(int id)
        {
            var cierreDeGavetas = await _context.CierreDeGaveta.FindAsync(id);

            if (cierreDeGavetas == null)
            {
                return NotFound();
            }

            return cierreDeGavetas;
        }

        // PUT: api/CierreDeGavetas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCierreDeGavetas(int id, CierreDeGavetas cierreDeGavetas)
        {
            if (id != cierreDeGavetas.ID)
            {
                return BadRequest();
            }

            _context.Entry(cierreDeGavetas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CierreDeGavetasExists(id))
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

        // POST: api/CierreDeGavetas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CierreDeGavetas>> PostCierreDeGavetas(CierreDeGavetas cierreDeGavetas)
        {
            AperturaDeGavetas aperturaCerrar = await _context.AperturaDeGavetas.FindAsync(cierreDeGavetas.AperturaQueCierra);
            cierreDeGavetas.Fecha = DateTime.Now;
            cierreDeGavetas.GavetasID = aperturaCerrar.GavetasID;
            //cierreDeGavetas.CierreDeGavetasID = aperturaCerrar.CierreDeGavetasID;
            _context.CierreDeGaveta.Add(cierreDeGavetas);
            await _context.SaveChangesAsync();
            foreach (var orden in cierreDeGavetas.OrdenesCerrar)
            {
                Orden ordenEditar =await _context.Ordenes.FindAsync(orden.ID);
                ordenEditar.CierreDeGavetasID = cierreDeGavetas.ID;
            }
            
            aperturaCerrar.CierreDeGavetasID = cierreDeGavetas.ID;
            if (cierreDeGavetas.IsCierreCiego)
            {
                cierreDeGavetas.IsCerrada = false;
            }
            else
            {
                cierreDeGavetas.IsCerrada = true;
            }
            await _context.LogGavetas.AddAsync(new LogGavetas { 
                Descripcion=((cierreDeGavetas.IsCierreCiego)?("Cierre ciego de gaveta") :("Cierre de gaveta")),
                Fecha=DateTime.Now,
                GavetasID=cierreDeGavetas.GavetasID,
                Modulo="cierre de gavetas controller",
                AperturaDeGavetasID=null,
                CierreDeGavetasID=cierreDeGavetas.ID
            });
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCierreDeGavetas", new { id = cierreDeGavetas.ID }, cierreDeGavetas);
        }

        // DELETE: api/CierreDeGavetas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CierreDeGavetas>> DeleteCierreDeGavetas(int id)
        {
            var cierreDeGavetas = await _context.CierreDeGaveta.FindAsync(id);
            if (cierreDeGavetas == null)
            {
                return NotFound();
            }

            _context.CierreDeGaveta.Remove(cierreDeGavetas);
            await _context.SaveChangesAsync();

            return cierreDeGavetas;
        }

        private bool CierreDeGavetasExists(int id)
        {
            return _context.CierreDeGaveta.Any(e => e.ID == id);
        }
    }
}
