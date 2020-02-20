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

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Clientes = await _db.Clientes.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var curso = await _db.Clientes.FindAsync(id);

            if (curso == null)
            {
                Mensaje = "Usuario no encontrado";
                return NotFound();
            }
            
            return RedirectToPage("Clientes");
        }
    }
}
