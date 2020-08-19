using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlymPOS.Models.DB
{
    public class Descuentos
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public double Monto { get; set; }
    }
}
