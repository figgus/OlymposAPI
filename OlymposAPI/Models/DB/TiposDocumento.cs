using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class TiposDocumento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int SiiID { get; set; }
        public bool IsHabilitado { get; set; }
    }
}
