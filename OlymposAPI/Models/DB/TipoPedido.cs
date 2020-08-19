using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookBasicApp.Models.DB
{
    public class TipoPedido
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }
    }
}
