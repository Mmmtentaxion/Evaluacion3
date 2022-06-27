using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evaluacion3.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblclases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblclases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblmarcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblmarcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblcaracteristicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionLarga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Traccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cambios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Combustible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    año = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InPantalla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marcaId = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    ClaseId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcaracteristicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblcaracteristicas_tblCategorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tblCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblcaracteristicas_tblclases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "tblclases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblcaracteristicas_tblmarcas_marcaId",
                        column: x => x.marcaId,
                        principalTable: "tblmarcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblcaracteristicas_tblTipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "tblTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblcaracteristicas_CategoriaId",
                table: "tblcaracteristicas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblcaracteristicas_ClaseId",
                table: "tblcaracteristicas",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblcaracteristicas_marcaId",
                table: "tblcaracteristicas",
                column: "marcaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblcaracteristicas_TipoId",
                table: "tblcaracteristicas",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblcaracteristicas");

            migrationBuilder.DropTable(
                name: "tblCategorias");

            migrationBuilder.DropTable(
                name: "tblclases");

            migrationBuilder.DropTable(
                name: "tblmarcas");

            migrationBuilder.DropTable(
                name: "tblTipos");
        }
    }
}
