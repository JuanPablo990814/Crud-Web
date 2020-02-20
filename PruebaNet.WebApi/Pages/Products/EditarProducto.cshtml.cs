using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaNet.Datos;

namespace PruebaNet.WebApi
{
    public class EditarProductoModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //constructor rapido (ctor)
        public EditarProductoModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //mensaje de creado
        [TempData]
        public string Mensaje { get; set; }

        [BindProperty]
        public Producto Producto { get; set; }


        public async Task OnGet(int id)
        {
            Producto = await _db.Producto.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursoDesdeDb = await _db.Producto.FindAsync(Producto.plu);
                CursoDesdeDb.nombre = Producto.nombre;
                CursoDesdeDb.descripcion = Producto.descripcion;
                CursoDesdeDb.marca = Producto.marca;
                CursoDesdeDb.cantidad = Producto.cantidad;
                CursoDesdeDb.disponible = Producto.disponible;
                CursoDesdeDb.valor = Producto.valor;
                CursoDesdeDb.valor_iva = Producto.valor_iva;

                await _db.SaveChangesAsync();

                Mensaje = "Registro editado correctamente";

                return RedirectToPage("Productos");
            }

            return RedirectToPage();
        }
    }
}
