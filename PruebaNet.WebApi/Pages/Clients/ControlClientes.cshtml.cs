using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaNet.Datos;

namespace PruebaNet.WebApi
{
    public class ControlClientesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //constructor rapido (ctor)

        //contexto de la db con el nombre de la clase
        public ControlClientesModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string Mensaje { get; set; }

        //public Curso Curso es la clase que tiene las variables que van a la base de datos
        [BindProperty]
        public Clientes Clientes { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Mensaje = "Ha Faltado llenar uno de los campos";
                return Page();
            }
            //Guarda en la base de datos
            _db.Add(Clientes);
            await _db.SaveChangesAsync();

            Mensaje = "Nuevo cliente agregado correctamente";

            //returnar la pagina de inicio
            return RedirectToPage("Clientes");

        }
    }
}