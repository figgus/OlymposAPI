using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class MediosDePago
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Nombre { get; set; }
        public bool IsEfectivo { get; set; }
        public bool IsTarjeta { get; set; }
        public bool IsCupon { get; set; }
        public int IndiceOrden { get; set; }
        public bool IsHabilitado { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string NombreImagen { get; set; }
    }
}
