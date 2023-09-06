using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteAPI.Migrations
{
    /// <inheritdoc />
    public partial class Quarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Cardapio_CardapiosId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Refeicao_RefeicoesId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOrder_Pedido_PedidosId",
                table: "MealOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOrder_Refeicao_RefeicaoId",
                table: "MealOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Refeicao",
                table: "Refeicao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cardapio",
                table: "Cardapio");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Refeicao",
                newName: "Meal");

            migrationBuilder.RenameTable(
                name: "Pedido",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Cardapio",
                newName: "Menu");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Order",
                newName: "IX_Order_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Meal_RefeicoesId",
                table: "MealMenu",
                column: "RefeicoesId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Menu_CardapiosId",
                table: "MealMenu",
                column: "CardapiosId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrder_Meal_RefeicaoId",
                table: "MealOrder",
                column: "RefeicaoId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrder_Order_PedidosId",
                table: "MealOrder",
                column: "PedidosId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UsuarioId",
                table: "Order",
                column: "UsuarioId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Meal_RefeicoesId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Menu_CardapiosId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOrder_Meal_RefeicaoId",
                table: "MealOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOrder_Order_PedidosId",
                table: "MealOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UsuarioId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Pedido");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Cardapio");

            migrationBuilder.RenameTable(
                name: "Meal",
                newName: "Refeicao");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UsuarioId",
                table: "Pedido",
                newName: "IX_Pedido_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cardapio",
                table: "Cardapio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Refeicao",
                table: "Refeicao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Cardapio_CardapiosId",
                table: "MealMenu",
                column: "CardapiosId",
                principalTable: "Cardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Refeicao_RefeicoesId",
                table: "MealMenu",
                column: "RefeicoesId",
                principalTable: "Refeicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrder_Pedido_PedidosId",
                table: "MealOrder",
                column: "PedidosId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrder_Refeicao_RefeicaoId",
                table: "MealOrder",
                column: "RefeicaoId",
                principalTable: "Refeicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuario_UsuarioId",
                table: "Pedido",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
