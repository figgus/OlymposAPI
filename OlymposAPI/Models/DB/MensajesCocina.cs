using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OlymposAPI.Models.DB
{
    public class MensajesCocina
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string MyProperty { get; set; }
    }
}
