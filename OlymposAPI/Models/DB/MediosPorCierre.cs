using HookBasicApp.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlymposAPI.Models.DB
{
    public class MediosPorCierre
    {
        public int ID { get; set; }
        public int MediosDePagoID { get; set; }
        public MediosDePago MediosDePago { get; set; }
        public Int64 Monto { get; set; }
    }
}
