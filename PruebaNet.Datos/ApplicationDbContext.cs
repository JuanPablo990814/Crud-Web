using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaNet.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Pedidos> Pedidos { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Produtos_Pedidos> Productos_Pedidos { get; set; }
    }
}
