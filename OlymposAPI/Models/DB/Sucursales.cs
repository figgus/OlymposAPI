

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class Sucursales
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int ConfigLocalID { get; set; }
        public ConfigLocal ConfigLocal { get; set; }
    }
}
