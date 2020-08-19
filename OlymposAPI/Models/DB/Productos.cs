

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class Productos
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Nombre { get; set; }
        public int PrecioParaLlevar { get; set; }
        public int PrecioMesa { get; set; }
        public int PrecioBar { get; set; }
        public int PrecioDelivery { get; set; }
        public DateTime FechaCracion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CategoriasID { get; set; }
        public Categorias Categorias { get; set; }
        public virtual ICollection<SucursalesProducto> SucursalesAsociadas { get; set; }
    }
}
