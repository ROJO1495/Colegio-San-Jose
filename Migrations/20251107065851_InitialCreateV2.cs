using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Colegio_San_Jose.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Alumnos__3214EC07A560DDDF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Creditos = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Materias__3214EC07B5F51A06", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    NotaFinal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Expedien__3214EC0777FEFBDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expedientes_Alumnos",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expedientes_Materias",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alumnos",
                columns: new[] { "Id", "Apellido", "Email", "FechaNacimiento", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Serrano", "nicole.serrano@colegio.edu", new DateTime(2012, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicole", "1234-5678" },
                    { 2, "Rivera", "claudia.rivera@colegio.edu", new DateTime(1987, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claudia", "2345-6789" },
                    { 3, "Torres", "amilcar.torres@colegio.edu", new DateTime(1985, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amilcar", "3456-7890" }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "Codigo", "Creditos", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "MAT101", 4, "Algebra y calculo basico", "Matematicas" },
                    { 2, "CNT201", 3, "Biologia, fisica y quimica", "Ciencias Naturales" },
                    { 3, "HIS301", 2, "Historia universal y nacional", "Historia" },
                    { 4, "LIT401", 3, "Analisis literario y redaccion", "Literatura" }
                });

            migrationBuilder.InsertData(
                table: "Expedientes",
                columns: new[] { "Id", "AlumnoId", "FechaInscripcion", "MateriaId", "NotaFinal", "Observaciones" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 85.5m, "Buen desempeño en examenes" },
                    { 2, 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 90.0m, "Excelente participacion" },
                    { 3, 2, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 78.0m, "Necesita mejorar en tareas" },
                    { 4, 3, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 92.5m, "Destacado en debates" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_AlumnoId",
                table: "Expedientes",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_MateriaId",
                table: "Expedientes",
                column: "MateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expedientes");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Materias");
        }
    }
}
