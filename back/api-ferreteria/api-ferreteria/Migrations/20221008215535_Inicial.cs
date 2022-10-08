using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_ferreteria.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    numdocumento = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPago", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    categoriaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_categoriaid",
                        column: x => x.categoriaid,
                        principalTable: "Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    rolid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.id);
                    table.ForeignKey(
                        name: "FK_Empleado_Rol_rolid",
                        column: x => x.rolid,
                        principalTable: "Rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    contraseña = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    pregunta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    respuesta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    empleadoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empleado_empleadoid",
                        column: x => x.empleadoid,
                        principalTable: "Empleado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comprobante",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    igv = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    clienteid = table.Column<int>(type: "int", nullable: true),
                    usuarioid = table.Column<int>(type: "int", nullable: true),
                    formapagoid = table.Column<int>(type: "int", nullable: true),
                    documentoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobante", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comprobante_Cliente_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comprobante_Documento_documentoid",
                        column: x => x.documentoid,
                        principalTable: "Documento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comprobante_FormaPago_formapagoid",
                        column: x => x.formapagoid,
                        principalTable: "FormaPago",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comprobante_Usuario_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    comprobanteid = table.Column<int>(type: "int", nullable: true),
                    productoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_Detalle_Comprobante_comprobanteid",
                        column: x => x.comprobanteid,
                        principalTable: "Comprobante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detalle_Producto_productoid",
                        column: x => x.productoid,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_clienteid",
                table: "Comprobante",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_documentoid",
                table: "Comprobante",
                column: "documentoid");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_formapagoid",
                table: "Comprobante",
                column: "formapagoid");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_usuarioid",
                table: "Comprobante",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_comprobanteid",
                table: "Detalle",
                column: "comprobanteid");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_productoid",
                table: "Detalle",
                column: "productoid");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_rolid",
                table: "Empleado",
                column: "rolid");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_categoriaid",
                table: "Producto",
                column: "categoriaid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_empleadoid",
                table: "Usuario",
                column: "empleadoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Comprobante");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "FormaPago");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
