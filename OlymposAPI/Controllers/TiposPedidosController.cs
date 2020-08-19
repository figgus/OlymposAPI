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
    public class TiposPedidosController : ControllerBase
    {
        private readonly ContextoDB _context;

        public TiposPedidosController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/TiposPedidos
        [HttpGet]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<IEnumerable<TipoPedido>>> GetTiposPedidos()
        {
            return await _context.TiposPedidos.ToListAsync();
        }

        // GET: api/TiposPedidos/5
        [HttpGet("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<TipoPedido>> GetTipoPedido(int id)
        {
            var tipoPedido = await _context.TiposPedidos.FindAsync(id);

            if (tipoPedido == null)
            {
                return NotFound();
            }

            return tipoPedido;
        }

        // PUT: api/TiposPedidos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<IActionResult> PutTipoPedido(int id, TipoPedido tipoPedido)
        {
            if (id != tipoPedido.ID)
            {
                return BadRequest();
            }

            _context.Entry(tipoPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPedidoExists(id))
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

        // POST: api/TiposPedidos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<TipoPedido>> PostTipoPedido(TipoPedido tipoPedido)
        {
            _context.TiposPedidos.Add(tipoPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPedido", new { id = tipoPedido.ID }, tipoPedido);
        }

        // DELETE: api/TiposPedidos/5
        [HttpDelete("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<TipoPedido>> DeleteTipoPedido(int id)
        {
            var tipoPedido = await _context.TiposPedidos.FindAsync(id);
            if (tipoPedido == null)
            {
                return NotFound();
            }

            _context.TiposPedidos.Remove(tipoPedido);
            await _context.SaveChangesAsync();

            return tipoPedido;
        }

        private bool TipoPedidoExists(int id)
        {
            return _context.TiposPedidos.Any(e => e.ID == id);
        }
    }
}
