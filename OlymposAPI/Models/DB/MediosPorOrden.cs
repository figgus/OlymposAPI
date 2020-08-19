using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class MediosPorOrden
    {
        public int ID { get; set; }
        public int OrdenID { get; set; }
        public int MediosDePagoID { get; set; }
        public MediosDePago MediosDePago { get; set; }
        public int MontoPagado { get; set; }
        public int MontoPagadoReal { get; set; }
    }
}
