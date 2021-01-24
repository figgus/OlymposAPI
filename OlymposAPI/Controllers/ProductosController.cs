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
    public class ProductosController : ControllerBase
    {
        private readonly ContextoDB _context;

        public ProductosController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        [EnableCors("PermitirConexion")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("GetProductosPorCategoria")]
        [EnableCors("PermitirConexion")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductosPorCategoria(int categoriaID,int sucursalID)
        {
            var res = await _context.Productos.Include(p=>p.SucursalesAsociadas).Where(p => p.CategoriasID == categoriaID && p.SucursalesAsociadas.Select(x => x.ID == sucursalID).Any()).ToListAsync();
            foreach (var producto in res)
            {
                producto.SucursalesAsociadas = null;
            }
            return res;
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Productos>> GetProductos(int id)
        {
            var productos = await _context.Productos.FindAsync(id);

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<IActionResult> PutProductos(int id, Productos productos)
        {
            if (id != productos.ID)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
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

        // POST: api/Productos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
            productos.Nombre = productos.Nombre.ToUpper();
            _context.Productos.Add(productos);
            await _context.SaveChangesAsync();
            foreach (var sucursal in productos.SucursalesAsociadas)
            {
                sucursal.ProductosID = productos.ID;
            }
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProductos", new { id = productos.ID });
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Productos>> DeleteProductos(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();

            return productos;
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.ID == id);
        }
    }
}
