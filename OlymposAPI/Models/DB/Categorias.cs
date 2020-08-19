

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class Categorias
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }
        public DateTime FechaCracion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual ICollection<SucursalesCategoria> SucursalesCategoria { get; set; }
    }
}
