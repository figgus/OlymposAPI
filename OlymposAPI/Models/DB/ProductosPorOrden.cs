using OlymposAPI.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class ProductosPorOrden
    {
        public int ID { get; set; }
        public int ProductosID { get; set; }
        public Productos Productos { get; set; }
        public int OrdenID { get; set; }
        public int Cantidad { get; set; }
        public int MontoDescuento { get; set; }
        public int PorcentajeDeDescuento { get; set; }
        public double TotalDescontado { get; set; }
        public virtual ICollection<MensajesProductos> MensajesProductos { get; set; }
    }
}
