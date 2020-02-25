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
        public Pedidos Pedidos { get; set; }
        public Producto Producto { get; set; }


        //Variables_Locales Variables;    

        [TempData]
        public string Mensaje { get; set; }

        [TempData]
        public Boolean formulario { get; set; }

        public async Task OnGet(int id)
        {
            Clientes = await _db.Clientes.ToListAsync();
            Producto = await _db.Producto.FindAsync(id);
        }



        public IActionResult OnPostBuscador(int cedula)
        {
            ///////Consulta por la cedula
            var cliente = _db.Clientes.FirstOrDefault(x => x.cedula == cedula);
            

            if (cliente != null)
            {
                
                cliente.id = cedula;
                //y devulve la id para iniciar el OnGet de Clientes.cshtml.cs que realiza la consulta de los datos con la id

                formulario = true;
                
            
                return RedirectToPage("", new { formulario });
            }

            Mensaje = "No se ha encontrado registro de la cedula en la base de datos, registra al usuario primero";

            return RedirectToPage("");
        }

        public IActionResult OnPostAggProducto(int pluproducto)
        {
            ///////Consulta por la cedula
            var producto = _db.Producto.FirstOrDefault(x => x.plu == pluproducto);
            int id;

            if (producto != null)
            {
                producto.plu = pluproducto;
                //y devulve la id para iniciar el OnGet de Clientes.cshtml.cs que realiza la consulta de los datos con la id

                id = pluproducto;

                return RedirectToPage("InicioPedido", new { id });
            }

            Mensaje = "No se ha encontrado registro de la cedula en la base de datos";

            return RedirectToPage("");
        }


    }
}
