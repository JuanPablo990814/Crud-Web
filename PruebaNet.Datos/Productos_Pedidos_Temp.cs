using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaNet.Datos
{
    public class Productos_Pedidos_Temp
    {

        [Key]
        public int id_temp { get; set; }

        public int? id_client { get; set; }

        public int? plu { get; set; }

        public int cantidad { get; set; }

        public double valor_total_producto { get; set; }

        public string nombreprod { get; set; }

        public double valor_producto { get; set; }

        [ForeignKey("id_client")]
        public Clientes clientes { get; set; }

        [ForeignKey("plu")]
        public Producto producto { get; set; }

    }
}
