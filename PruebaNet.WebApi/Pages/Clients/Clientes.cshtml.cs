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
    public class ClientesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ClientesModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Clientes> Clientes { get; set; }

            [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Clientes = await _db.Clientes.ToListAsync();
        }

        //Metodo para busca el usuario por la cedula
        //

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var cliente = await _db.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _db.Clientes.Remove(cliente);
            await _db.SaveChangesAsync();

            return RedirectToPage("Clientes");
        }

        public IActionResult OnPostBuscador(int cedula)
        {
            ///////Consulta por la cedula
            var cliente = _db.Clientes.FirstOrDefault(x => x.cedula == cedula);


            if (cliente != null)
            {
                cliente.cedula = cedula;
                //y devulve la id para iniciar el OnGet de Clientes.cshtml.cs que realiza la consulta de los datos con la id
                //Client.id = cliente.id;

                return RedirectToPage("EditarClientes", new { cliente.id });
            }

            Mensaje = "No se ha encontrado registro de la cedula en la base de datos";

            return RedirectToPage("");
        }
    }
}