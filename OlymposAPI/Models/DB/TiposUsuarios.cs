using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlymPOS.Models.DB
{
    public class TiposUsuarios
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSuperAdmin { get; set; }
    }
}
