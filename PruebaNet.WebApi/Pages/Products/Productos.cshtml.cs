﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PruebaNet.Datos;

namespace PruebaNet.WebApi
{
    public class ProductosModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ProductosModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Producto> Productos { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Productos = await _db.Producto.ToListAsync();
        }

        public void lol()
        {
            
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var producto = await _db.Producto.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _db.Producto.Remove(producto);
            await _db.SaveChangesAsync();

            return RedirectToPage("Productos");
        }

        public IActionResult OnPostBuscador(int pluproducto)
        {
            ///////Consulta por la cedula
            var producto = _db.Producto.FirstOrDefault(x => x.plu == pluproducto);
            int id;

            if (producto != null)
            {
                producto.plu = pluproducto;
                //y devulve la id para iniciar el OnGet de Clientes.cshtml.cs que realiza la consulta de los datos con la id

                id = pluproducto;

                return RedirectToPage("EditarProducto", new { id });
            }

            Mensaje = "No se ha encontrado registro de la cedula en la base de datos";

            return RedirectToPage("");
        }
    }
}