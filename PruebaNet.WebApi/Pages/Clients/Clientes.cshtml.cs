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

        //public Clientes Client { get; set; }

        public IEnumerable<Clientes> Clientes { get; set; }

        public Clientes Clien { get; set; }

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

        //prueba git
        public async Task<IActionResult> OnGetBuscador(int cedula)
        {
            var cliente = await _db.Clientes.FindAsync(cedula);

            if (cliente == null )
            {
                Mensaje = "No se encuentra el cliente en la base de datos";

                // para returnar a la pantalla negra return NotFound();
                return RedirectToPage("Index");
            }

            //cliente.cedula = Client.cedula;
            //cliente.nombres = Client.nombres;
            //cliente.email = Client.email;
            //cliente.telefono = Client.telefono;
            //cliente.direccion = Client.direccion;

            return RedirectToPage("EditarClientes");
        }
    }
}