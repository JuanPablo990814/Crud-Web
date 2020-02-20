using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PruebaNet.Datos
{
    [Table("tblClientes")]//Para tener un nombre diferente al de la clase, si no se llamaria solo Clientes
    public class Clientes
    {
        [Key]
        public int id { get; set; } 

        [Required]
        public int cedula { get; set; }

        [Required] //not null
        public string nombres { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }

        public Clientes Where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
