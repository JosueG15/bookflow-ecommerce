using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixPaymentIntentTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "paymentIntentId",
                table: "OrderHeaders",
                newName: "PaymentIntentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentIntentId",
                table: "OrderHeaders",
                newName: "paymentIntentId");
        }
    }
}
