using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaNet.Datos
{
    [Table("tblProductos_Pedidos")]
    public class Produtos_Pedidos
    {
        [Key]
        public int id { get; set; }

        public int? id_ped { get; set; }
        
        public int? plu { get; set; }


        [ForeignKey("id_ped")]
        public Pedidos pedidos { get; set; }

        [ForeignKey("plu")]
        public Producto producto { get; set; }
    }
}
