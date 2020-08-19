using OlymPOS.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HookBasicApp.Models.DB
{
    public class Orden
    {
        [Key]
        public int  ID{ get; set; }
        public double Total { get; set; }
        public double Subtotal { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        [DefaultValue("getdate()")]
        public DateTime FechaModificacion { get; set; }
        public int UsuariosID{ get; set; }
        public Usuarios Usuarios { get; set; }
        public int TipoPedidoID { get; set; }
        public TipoPedido TipoPedido { get; set; }
        public virtual ICollection<ProductosPorOrden> ProductosPorOrden { get; set; }
        public virtual ICollection<MediosPorOrden> MediosPorOrden { get; set; }
        public double DescuentoTotal { get; set; }
        public double PorcentajeDescuento { get; set; }
        public double MontoExactoDescuento { get; set; }
        public bool IsPagada { get; set; }
        public double Vuelto { get; set; }
        public int? TiposDocumentoID { get; set; }
        public TiposDocumento TiposDocumento { get; set; }
        public int NumeroDeOrden { get; set; }
        public int SucursalesID { get; set; }
        public Sucursales Sucursal { get; set; }
        public int? AperturaDeGavetasID { get; set; }
        public AperturaDeGavetas AperturaDeGaveta { get; set; }
        public int? CierreDeGavetasID { get; set; }
        public CierreDeGavetas CierreDeGaveta { get; set; }
        public bool IsAnulada { get; set; }
        public int MontoPropina { get; set; }
        public int? GavetasID { get; set; }
        public Gavetas Gavetas { get; set; }
    }
}
