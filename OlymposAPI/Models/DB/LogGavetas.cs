using OlymPOS.Models.DB;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HookBasicApp.Models.DB
{
    public class LogGavetas
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int GavetasID { get; set; }
        public Gavetas Gaveta { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Modulo { get; set; }
        public int? AperturaDeGavetasID { get; set; }
        public AperturaDeGavetas AperturaDeGavetas { get; set; }
        public int? CierreDeGavetasID { get; set; }
        public CierreDeGavetas CierreDeGaveta { get; set; }
    }
}
