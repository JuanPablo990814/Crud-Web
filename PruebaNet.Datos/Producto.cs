using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaNet.Datos
{
    [Table("tblProducto")]
    public class Producto
    {
        [Key]
        public int plu { get; set; }

        [Required]
        public string nombre { get; set; }

        public string descripcion { get; set; }

        public string marca { get; set; }

        public int cantidad { get; set; }

        public string disponible { get; set; }

        public double valor { get; set; }

        public double valor_iva { get; set; }
    }
}
