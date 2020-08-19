using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class SucursalesCategoria
    {
        public int ID { get; set; }
        public int SucursalesID { get; set; }
        public Sucursales Sucursales { get; set; }
        public int CategoriasID { get; set; }
        public Categorias Categorias { get; set; }
    }
}
