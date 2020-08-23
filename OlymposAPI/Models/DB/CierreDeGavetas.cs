using HookBasicApp.Models.DB;
using OlymposAPI.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual ICollection<MediosPorCierre> MediosPorCierre { get; set; }
        [NotMapped]
        public virtual ICollection<Orden> OrdenesCerrar { get; set; }
        [NotMapped]
        public int AperturaQueCierra { get; set; }
        public int? CierreDeGavetasID { get; set; }
        public CierreDeGavetas CierreCiegoAsociado { get; set; }
        public bool IsCerrada { get; set; }
    }
}
