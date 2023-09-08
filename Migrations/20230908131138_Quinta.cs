using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteAPI.Migrations
{
    /// <inheritdoc />
    public partial class Quinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Menu_CardapiosId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOrder_Order_PedidosId",
                table: "MealOrder");

            migrationBuilder.RenameColumn(
                name: "PedidosId",
                table: "MealOrder",
                newName: "PedidoId");

            migrationBuilder.RenameColumn(
                name: "CardapiosId",
                table: "MealMenu",
                newName: "CardapioId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Menu_CardapioId",
                table: "MealMenu",
                column: "CardapioId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrder_Order_PedidoId",
                table: "MealOrder",
                column: "PedidoId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Menu_CardapioId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOrder_Order_PedidoId",
                table: "MealOrder");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "MealOrder",
                newName: "PedidosId");

            migrationBuilder.RenameColumn(
                name: "CardapioId",
                table: "MealMenu",
                newName: "CardapiosId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Menu_CardapiosId",
                table: "MealMenu",
                column: "CardapiosId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrder_Order_PedidosId",
                table: "MealOrder",
                column: "PedidosId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
