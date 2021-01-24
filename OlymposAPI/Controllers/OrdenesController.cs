using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlymposAPI.DAL;
using HookBasicApp.Models.DB;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using OlymposAPI.Models.DB;

namespace HookBasicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    //[EnableCors("PermitirConexion")]
    public class OrdenesController : ControllerBase
    {
        private readonly ContextoDB _context;

        public OrdenesController(ContextoDB context)
        {
            _context = context;
        }

        // GET: api/Ordenes
        [HttpGet]
        //[EnableCors("PermitirConexion")]
        public async Task<ActionResult<IEnumerable<Orden>>> GetOrdenes(string fechaDesde,int sucursalID)
        {

            DateTime fecha = DateTime.MinValue;
            if (fechaDesde != null)
            {
                fecha = DateTime.Parse(fechaDesde);
            }
            if (fecha != DateTime.MinValue)
            {
                return await _context.Ordenes.Where(p => p.FechaCreacion.Date == fecha.Date 
                && !p.IsPagada 
                && !p.IsAnulada
                && p.SucursalesID==sucursalID)
                    .Include(p => p.TipoPedido).
                Include(p => p.Usuarios).OrderByDescending(p=>p.FechaCreacion).ToListAsync();
            }
            else
            {
                var res = await _context.Ordenes
                    .Where(p => p.FechaCreacion.Date == DateTime.Now.Date 
                    && !p.IsPagada 
                    && !p.IsAnulada
                    && p.SucursalesID==sucursalID).Include(p => p.TipoPedido).
                Include(p => p.Usuarios).OrderByDescending(p => p.FechaCreacion).ToListAsync();
                return res;
            }
        }

        // GET: api/Ordenes/5
        [HttpGet("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Orden>> GetOrden(int id)
        {
            var orden = await _context.Ordenes
                .Include(p=>p.TipoPedido)
                .Include(p=>p.ProductosPorOrden).ThenInclude(p=>p.Productos)
                .Include(p=>p.ProductosPorOrden).ThenInclude(p=>p.MensajesProductos)
                .Include(p=>p.Usuarios)
                .FirstOrDefaultAsync(p=>p.ID==id);

            if (orden == null)
            {
                return NotFound();
            }
            foreach (var prod in orden.ProductosPorOrden)
            {
                foreach (var mensaje in prod.MensajesProductos)
                {
                    mensaje.ProductosPorOrden = null;
                }
            }
            return orden;
        }

        // PUT: api/Ordenes/5
        [HttpPut("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<IActionResult> PutOrden(int id, Orden orden)
        {
            if (id != orden.ID)
            {
                return BadRequest();
            }

            _context.Entry(orden).State = EntityState.Modified;

            var productosAnteriores = _context.ProductosPorOrden.Where(p => p.OrdenID == orden.ID).ToList();
            _context.RemoveRange(productosAnteriores);
            await _context.SaveChangesAsync();

            foreach (var productoOrden in orden.ProductosPorOrden)
            {
                productoOrden.Productos = null;
                productoOrden.ID = 0;
                await _context.ProductosPorOrden.AddAsync(productoOrden);
                foreach (var mensaje in productoOrden.MensajesProductos)
                {
                    mensaje.ID = 0;
                }
            }
            
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {

            }

            return NoContent();
        }

        private async Task<bool> BorrarProductos(List<ProductosPorOrden> listaAnterior, List<ProductosPorOrden> listaNueva)
        {
            List<ProductosPorOrden> res = new List<ProductosPorOrden>();
            foreach (var productoAnterior in listaAnterior)
            {
                bool any = listaNueva.Any(p => p.ID == productoAnterior.ID);
                if (!any)
                {
                    res.Add(productoAnterior);
                }
            }
            if (res.Count > 0)
            {
                _context.RemoveRange(res);
                await _context.SaveChangesAsync();

            }

            return true;
            
        }

        private bool IsIdentico(ProductosPorOrden productoOriginal, ProductosPorOrden productoNuevo)
        {
            bool res = false;
            foreach (PropertyInfo prop in productoOriginal.GetType().GetProperties())
            {
                res = prop.GetValue(productoOriginal, null).Equals(prop.GetValue(productoNuevo, null));

                if (res)
                {
                    break;
                }
            }
            return res;
        }

        // POST: api/Ordenes
        [HttpPost]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Orden>> PostOrden(Orden orden)
        {
            orden.TipoPedido = null;
            orden.Usuarios = null;
            Usuarios usuario = _context.Usuarios.Find(orden.UsuariosID);
            orden.FechaCreacion = DateTime.Now;

            try
            {
                var ultimaOrden = _context.Ordenes.ToList().Last(p => p.SucursalesID == orden.SucursalesID);
                orden.NumeroDeOrden = ultimaOrden.NumeroDeOrden + 1;
            }
            catch (Exception ex)
            {
                orden.NumeroDeOrden = 1;
            }
            
            
            
            
            if (orden.ProductosPorOrden.Count(p=>p.Productos!=null)>0)
            {
                foreach (var productoOrden in orden.ProductosPorOrden)
                {
                    productoOrden.Productos = null;
                }
            }
            
            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();
            orden.ProductosPorOrden = null;
            return Ok(orden);
        }

        // DELETE: api/Ordenes/5
        [HttpDelete("{id}")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Orden>> DeleteOrden(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }

            _context.Ordenes.Remove(orden);
            await _context.SaveChangesAsync();

            return orden;
        }

        private bool OrdenExists(int id)
        {
            return _context.Ordenes.Any(e => e.ID == id);
        }

        [HttpPut("PagarOrden")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Orden>> PagarOrden(Orden orden)
        {
            var ordenEditar =await _context.Ordenes.FindAsync(orden.ID);
            ordenEditar.IsPagada = true;
            
            int cont = 0;
            foreach (var medio in orden.MediosPorOrden)
            {
                medio.MontoPagadoReal = medio.MontoPagado - (int)orden.Vuelto;
                if (cont == orden.MediosPorOrden.Count-1)
                {
                    medio.MontoPagadoReal = medio.MontoPagado- (int)orden.Vuelto;
                    if (!medio.MediosDePago.IsEfectivo)
                    {
                        
                        ordenEditar.MontoPropina = (int)orden.Vuelto;
                        ordenEditar.Vuelto = 0;
                    }
                    else
                    {

                        ordenEditar.Vuelto = orden.Vuelto;
                    }
                }
                medio.MediosDePago = null;
                await _context.MediosPorOrden.AddAsync(medio);
                cont++;

            }
            await _context.SaveChangesAsync();
            return Ok(ordenEditar);
        }

        [HttpPut("AnularOrden")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<Orden>> AnularOrden(int id)
        {
            var ordenEditar = await _context.Ordenes.FindAsync(id);
            ordenEditar.IsAnulada = true;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("GetOrdenesPendientes")]
        [EnableCors("PermitirConexion")]
        public async Task<ActionResult<IEnumerable<Orden>>> GetOrdenesPendientes(int aperturaID)
        {
            var apertura = _context.AperturaDeGavetas.Include(p=>p.Usuario).FirstOrDefault(p=>p.ID==aperturaID);
            var res = await _context.Ordenes
                .Include(p=>p.AperturaDeGaveta)
                .Include(p=>p.MediosPorOrden)
                .Include(p=>p.Usuarios)
                .Include(p=>p.CierreDeGaveta)
                .Where(p=>(p.AperturaDeGavetasID==aperturaID ||
                p.Usuarios.EstacionesID==apertura.Usuario.EstacionesID)
                && (p.CierreDeGavetasID==null || p.CierreDeGaveta.IsCierreCiego)
                && p.IsPagada)
                .ToListAsync();
            return res;
        }
    }
}
