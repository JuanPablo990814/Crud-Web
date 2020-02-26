using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PruebaNet.Datos;

namespace PruebaNet.WebApi
{
    public class InicioPedidoModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public InicioPedidoModel(ApplicationDbContext db)
        {
            _db = db;
        }

        

        public IEnumerable<Clientes> Clientes { get; set; }
        public IEnumerable<Producto> ProdInum { get; set; }
        public IEnumerable<Productos_Pedidos_Temp> TemporalInum { get; set; }
        public Pedidos Pedidos { get; set; }
        public Producto Producto { get; set; }
        public Clientes Client { get; set; }
        public Productos_Pedidos_Temp Temporal { get; set; }

        

        //Variables_Locales Variables;    

        [TempData]
        public string Mensaje { get; set; }

        [TempData]
        public int idcliente { get; set; }

        [TempData]
        public int idplu { get; set; }


        [TempData]
        public Boolean formulario { get; set; }

        public async Task OnGet(int id)
        {
            Clientes = await _db.Clientes.ToListAsync();
            Producto = await _db.Producto.FindAsync(id);
            TemporalInum = await _db.Temporal.ToListAsync();
            ProdInum = await _db.Producto.ToListAsync();
        }

            public IActionResult OnPostBuscador(int cedula)
            {
                ///////Consulta por la cedula
                var cliente = _db.Clientes.FirstOrDefault(x => x.cedula == cedula);
            

                if (cliente != null)
                {
                    idcliente = cliente.id;
                    cliente.id = cedula;
                    //y devulve la id para iniciar el OnGet de Clientes.cshtml.cs que realiza la consulta de los datos con la id

                    formulario = true;
      
                    return RedirectToPage("InicioPedido", new { formulario });
                }

                Mensaje = "No se ha encontrado registro de la cedula en la base de datos, registra al usuario primero";

                return RedirectToPage("");
            }

        public IActionResult OnPostBProducto(int pluproducto,int numcliente)
        {
            ///////Consulta por la cedula
            var producto = _db.Producto.FirstOrDefault(x => x.plu == pluproducto);
            int id; 

            if (producto != null)
            {
                producto.plu = pluproducto;
                //y devulve la id para iniciar el OnGet de Clientes.cshtml.cs que realiza la consulta de los datos con la id

                id = pluproducto;
                formulario = true;
                idcliente = numcliente;
                idplu = pluproducto;

                return RedirectToPage("InicioPedido", new { id });
            }

            Mensaje = "No se ha encontrado registro de la cedula en la base de datos";

            return RedirectToPage("");
        }

        //agregar la tabla temporal
        public async Task<IActionResult> OnPostAggProductoAsync(int numplu, int numcliente,int cantidad, int valor, string nombreprod)
        {
            if (ModelState.IsValid)
            {
                Temporal = new Productos_Pedidos_Temp();
                Temporal.id_client = numcliente;
                Temporal.plu = numplu;
                Temporal.cantidad = cantidad;
                Temporal.valor_producto = valor;
                Temporal.nombreprod = nombreprod;
                Temporal.valor_total_producto = valor * cantidad;


                _db.Add(Temporal);
                await _db.SaveChangesAsync();

                Mensaje = "Producto agregado correctamente";
                formulario = true;

                return RedirectToPage("InicioPedido");
            }

            return RedirectToPage();
        }


    }
}
