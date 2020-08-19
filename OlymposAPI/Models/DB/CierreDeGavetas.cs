using HookBasicApp.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlymPOS.Models.DB
{
    public class CierreDeGavetas
    {
        public int ID { get; set; }
        public int GavetasID { get; set; }
        public Gavetas Gavetas { get; set; }
        public DateTime Fecha { get; set; }
        public bool IsCierreCiego { get; set; }

    }
}
