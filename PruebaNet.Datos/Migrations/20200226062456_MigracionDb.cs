using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaNet.Datos.Migrations
{
    public partial class MigracionDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblClientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cedula = table.Column<int>(nullable: false),
                    nombres = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    telefono = table.Column<int>(nullable: false),
                    direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblProducto",
                columns: table => new
                {
                    plu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    marca = table.Column<string>(nullable: true),
                    cantidad = table.Column<int>(nullable: false),
                    disponible = table.Column<string>(nullable: true),
                    valor = table.Column<double>(nullable: false),
                    valor_iva = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducto", x => x.plu);
                });

            migrationBuilder.CreateTable(
                name: "tblPedidos",
                columns: table => new
                {
                    id_ped = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_cliente = table.Column<int>(nullable: true),
                    persona_recibe = table.Column<string>(nullable: true),
                    observaciones_gene = table.Column<string>(nullable: true),
                    valor_total = table.Column<double>(nullable: false),
                    ced = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPedidos", x => x.id_ped);
                    table.ForeignKey(
                        name: "FK_tblPedidos_tblClientes_ced",
                        column: x => x.ced,
                        principalTable: "tblClientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temporal",
                columns: table => new
                {
                    id_temp = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_client = table.Column<int>(nullable: true),
                    plu = table.Column<int>(nullable: true),
                    cantidad = table.Column<int>(nullable: false),
                    valor_total_producto = table.Column<double>(nullable: false),
                    nombreprod = table.Column<string>(nullable: true),
                    valor_producto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporal", x => x.id_temp);
                    table.ForeignKey(
                        name: "FK_Temporal_tblClientes_id_client",
                        column: x => x.id_client,
                        principalTable: "tblClientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Temporal_tblProducto_plu",
                        column: x => x.plu,
                        principalTable: "tblProducto",
                        principalColumn: "plu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblProductos_Pedidos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_ped = table.Column<int>(nullable: true),
                    plu = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductos_Pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblProductos_Pedidos_tblPedidos_id_ped",
                        column: x => x.id_ped,
                        principalTable: "tblPedidos",
                        principalColumn: "id_ped",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblProductos_Pedidos_tblProducto_plu",
                        column: x => x.plu,
                        principalTable: "tblProducto",
                        principalColumn: "plu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPedidos_ced",
                table: "tblPedidos",
                column: "ced");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductos_Pedidos_id_ped",
                table: "tblProductos_Pedidos",
                column: "id_ped");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductos_Pedidos_plu",
                table: "tblProductos_Pedidos",
                column: "plu");

            migrationBuilder.CreateIndex(
                name: "IX_Temporal_id_client",
                table: "Temporal",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_Temporal_plu",
                table: "Temporal",
                column: "plu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductos_Pedidos");

            migrationBuilder.DropTable(
                name: "Temporal");

            migrationBuilder.DropTable(
                name: "tblPedidos");

            migrationBuilder.DropTable(
                name: "tblProducto");

            migrationBuilder.DropTable(
                name: "tblClientes");
        }
    }
}
