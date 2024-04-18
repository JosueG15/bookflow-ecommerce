using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoFinal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Santa Tecla", "Libros El Progreso", "7788-3344", "CP 1106", "La Libertad", "Calle al paraiso, edificio rojo numero 24" },
                    { 2, "Santa Tecla", "Libros El Retroceso", "7777-4444", "CP 1107", "La Libertad", "Calle al paraiso, edificio azul numero 25" },
                    { 3, "Santa Tecla", "Libros El Lento", "8888-3333", "CP 1108", "La Libertad", "Calle al paraiso, edificio morado numero 26" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
