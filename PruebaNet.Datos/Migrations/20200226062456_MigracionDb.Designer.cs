﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaNet.Datos;

namespace PruebaNet.Datos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200226062456_MigracionDb")]
    partial class MigracionDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PruebaNet.Datos.Clientes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cedula");

                    b.Property<string>("direccion");

                    b.Property<string>("email");

                    b.Property<string>("nombres")
                        .IsRequired();

                    b.Property<int>("telefono");

                    b.HasKey("id");

                    b.ToTable("tblClientes");
                });

            modelBuilder.Entity("PruebaNet.Datos.Pedidos", b =>
                {
                    b.Property<int>("id_ped")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ced");

                    b.Property<int?>("id_cliente");

                    b.Property<string>("observaciones_gene");

                    b.Property<string>("persona_recibe");

                    b.Property<double>("valor_total");

                    b.HasKey("id_ped");

                    b.HasIndex("ced");

                    b.ToTable("tblPedidos");
                });

            modelBuilder.Entity("PruebaNet.Datos.Producto", b =>
                {
                    b.Property<int>("plu")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cantidad");

                    b.Property<string>("descripcion");

                    b.Property<string>("disponible");

                    b.Property<string>("marca");

                    b.Property<string>("nombre")
                        .IsRequired();

                    b.Property<double>("valor");

                    b.Property<double>("valor_iva");

                    b.HasKey("plu");

                    b.ToTable("tblProducto");
                });

            modelBuilder.Entity("PruebaNet.Datos.Productos_Pedidos_Temp", b =>
                {
                    b.Property<int>("id_temp")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cantidad");

                    b.Property<int?>("id_client");

                    b.Property<string>("nombreprod");

                    b.Property<int?>("plu");

                    b.Property<double>("valor_producto");

                    b.Property<double>("valor_total_producto");

                    b.HasKey("id_temp");

                    b.HasIndex("id_client");

                    b.HasIndex("plu");

                    b.ToTable("Temporal");
                });

            modelBuilder.Entity("PruebaNet.Datos.Produtos_Pedidos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("id_ped");

                    b.Property<int?>("plu");

                    b.HasKey("id");

                    b.HasIndex("id_ped");

                    b.HasIndex("plu");

                    b.ToTable("tblProductos_Pedidos");
                });

            modelBuilder.Entity("PruebaNet.Datos.Pedidos", b =>
                {
                    b.HasOne("PruebaNet.Datos.Clientes", "clientes")
                        .WithMany()
                        .HasForeignKey("ced");
                });

            modelBuilder.Entity("PruebaNet.Datos.Productos_Pedidos_Temp", b =>
                {
                    b.HasOne("PruebaNet.Datos.Clientes", "clientes")
                        .WithMany()
                        .HasForeignKey("id_client");

                    b.HasOne("PruebaNet.Datos.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("plu");
                });

            modelBuilder.Entity("PruebaNet.Datos.Produtos_Pedidos", b =>
                {
                    b.HasOne("PruebaNet.Datos.Pedidos", "pedidos")
                        .WithMany()
                        .HasForeignKey("id_ped");

                    b.HasOne("PruebaNet.Datos.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("plu");
                });
#pragma warning restore 612, 618
        }
    }
}