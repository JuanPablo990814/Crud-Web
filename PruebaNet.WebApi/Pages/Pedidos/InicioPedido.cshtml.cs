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


        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Clientes = await _db.Clientes.ToListAsync();
        }


        public IActionResult OnPostBuscador(int cedula, Boolean form)
        {
            ///////Consulta por la cedula
            var cliente = _db.Clientes.FirstOrDefault(x => x.cedula == cedula);
            

            if (cliente != null)
            {
                cliente.id = cedula;
                //y devulve la id para iniciar el OnGet de Clientes.cshtml.cs que realiza la consulta de los datos con la id
                form = true;
                
                return RedirectToPage("InicioPedido", new { form });
            }

            Mensaje = "No se ha encontrado registro de la cedula en la base de datos, registra al usuario primero";

            return RedirectToPage("");
        }
    }
}
