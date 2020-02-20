using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaNet.Datos
{
    [Table("tblPedidos")]//Para tener un nombre diferente al de la clase
    public class Pedidos
    {
 
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Numero de Pedido")]
        public int id_ped { get; set; }

        [Display(Name = "Id del cliente")]//foreign key
        public int? id_cliente { get; set; }

        [Display(Name ="Persona que Recibe")]
        public string persona_recibe{get;set;}

        [Display(Name = "Observaciones Generales")]
        public string observaciones_gene { get; set; }

        [Display(Name = "Valor Total")]
        public double valor_total { get; set; }

        //Foreign Key
        [ForeignKey("ced")]
        public Clientes clientes { get; set; }

    }
}