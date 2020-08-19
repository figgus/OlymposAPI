

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class ConfigLocal
    {
        public int ID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UrlAfterParaLlevar { get; set; }
        public string UrlAfterMesa { get; set; }
        public string UrlAfteBar { get; set; }
        public string UrlAfterDelivery { get; set; }
    }
}
