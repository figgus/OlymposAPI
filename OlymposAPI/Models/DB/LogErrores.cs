using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OlymposAPI.Models.DB
{
    public class LogErrores
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Modulo { get; set; }
    }
}
