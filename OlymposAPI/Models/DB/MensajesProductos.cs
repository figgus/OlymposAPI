using HookBasicApp.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OlymposAPI.Models.DB
{
    public class MensajesProductos
    {
        public int ID { get; set; }
        public int ProductosPorOrdenID { get; set; }
        public ProductosPorOrden ProductosPorOrden { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Mensaje { get; set; }

    }
}
