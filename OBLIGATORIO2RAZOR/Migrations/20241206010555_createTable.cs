using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBLIGATORIO2RAZOR.Migrations
{
    public partial class createTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoHabitacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Tarifa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CorreoElectronico = table.Column<string>(name: "Correo Electronico", type: "nvarchar(max)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroHabitacion = table.Column<int>(type: "int", nullable: false),
                    HuespedId = table.Column<int>(type: "int", nullable: false),
                    FechaI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaF = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaR = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservas_Habitaciones_numeroHabitacion",
                        column: x => x.numeroHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_HuespedId",
                        column: x => x.HuespedId,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Habitaciones",
                columns: new[] { "Numero", "Capacidad", "Tarifa", "TipoHabitacion" },
                values: new object[,]
                {
                    { 101, 1, 50m, "Individual" },
                    { 102, 2, 75m, "Doble" },
                    { 103, 3, 100m, "Triple" },
                    { 104, 4, 150m, "Suite" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID", "Contrasenia", "Nombre", "Telefono", "Correo Electronico" },
                values: new object[,]
                {
                    { 1, "password", "Juan Perez", "1234567890", "juan@correo.com" },
                    { 2, "password123", "Maria Lopez", "1234567890", "maria@correo.com" },
                    { 3, "password456", "Carlos Gomez", "1234567890", "carlos@correo.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_HuespedId",
                table: "Reservas",
                column: "HuespedId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_numeroHabitacion",
                table: "Reservas",
                column: "numeroHabitacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
