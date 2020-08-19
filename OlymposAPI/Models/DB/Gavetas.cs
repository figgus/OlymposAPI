using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class Gavetas
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int FondoDeCaja { get; set; }

        public virtual ICollection<LogGavetas> LogGavetas { get; set; }
       
        public int SucursalesID { get; set; }
        public bool IsHabilitado { get; set; }
    }
}
