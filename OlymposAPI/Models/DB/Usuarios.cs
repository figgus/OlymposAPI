using OlymPOS.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class Usuarios
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string pin { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Apellido { get; set; }
        [DefaultValue("getdate()")]
        public DateTime FechaCreacion { get; set; }
        [DefaultValue("getdate()")]
        public DateTime FechaModificacion { get; set; }
        public int SucursalesID { get; set; }
        public Sucursales Sucursal { get; set; }
        public int EstacionesID { get; set; }
        public Estaciones Estacion { get; set; }
        public int TiposUsuariosID { get; set; }
        public TiposUsuarios TipoUsuario { get; set; }
        [NotMapped]
        public string JWT { get; set; }
    }
}
