using OlymPOS.Models.DB;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HookBasicApp.Models.DB
{
    public class AperturaDeGavetas
    {
        public int ID { get; set; }
        public int GavetasID { get; set; }
        [ForeignKey("GavetasID")]
        public Gavetas Gaveta { get; set; }
        public DateTime FechaDeApertura { get; set; }
        public int FondoDeCaja { get; set; }
        public int SucursalesID { get; set; }
        public Sucursales Sucursal { get; set; }
        public int UsuariosID { get; set; }
        public Usuarios Usuario { get; set; }
        public int? CierreDeGavetasID { get; set; }
        public CierreDeGavetas CierreDeGaveta { get; set; }
    }
}
