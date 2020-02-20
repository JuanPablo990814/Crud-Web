using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaNet.Datos;

namespace PruebaNet.WebApi
{
    public class EditarClientesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //constructor rapido (ctor)
        public EditarClientesModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //mensaje de creado
        [TempData]
        public string Mensaje { get; set; }

        [BindProperty]
        public Clientes Clientes { get; set; }


        public async Task OnGet(int id)
        {
            Clientes = await _db.Clientes.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursoDesdeDb = await _db.Clientes.FindAsync(Clientes.id);
                CursoDesdeDb.cedula = Clientes.cedula;
                CursoDesdeDb.nombres = Clientes.nombres;
                CursoDesdeDb.email = Clientes.email;
                CursoDesdeDb.telefono = Clientes.telefono;
                CursoDesdeDb.direccion = Clientes.direccion;

                await _db.SaveChangesAsync();

                Mensaje = "Registro editado correctamente";

                return RedirectToPage("Clientes");
            }

            return RedirectToPage();
        }
    }
}