using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteAPI.Migrations
{
    /// <inheritdoc />
    public partial class Terceira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Cardapio_CardapioId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Refeicao_RefeicaoId",
                table: "MealMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardapioRefeicao",
                table: "CardapioRefeicao");

            migrationBuilder.RenameTable(
                name: "CardapioRefeicao",
                newName: "MenuMeal");

            migrationBuilder.RenameColumn(
                name: "RefeicaoId",
                table: "MealMenu",
                newName: "RefeicoesId");

            migrationBuilder.RenameColumn(
                name: "CardapioId",
                table: "MealMenu",
                newName: "CardapiosId");

            migrationBuilder.RenameIndex(
                name: "IX_MealMenu_RefeicaoId",
                table: "MealMenu",
                newName: "IX_MealMenu_RefeicoesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuMeal",
                table: "MenuMeal",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Cardapio_CardapiosId",
                table: "MealMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_MealMenu_Refeicao_RefeicoesId",
                table: "MealMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuMeal",
                table: "MenuMeal");

            migrationBuilder.RenameTable(
                name: "MenuMeal",
                newName: "CardapioRefeicao");

            migrationBuilder.RenameColumn(
                name: "RefeicoesId",
                table: "MealMenu",
                newName: "RefeicaoId");

            migrationBuilder.RenameColumn(
                name: "CardapiosId",
                table: "MealMenu",
                newName: "CardapioId");

            migrationBuilder.RenameIndex(
                name: "IX_MealMenu_RefeicoesId",
                table: "MealMenu",
                newName: "IX_MealMenu_RefeicaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardapioRefeicao",
                table: "CardapioRefeicao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Cardapio_CardapioId",
                table: "MealMenu",
                column: "CardapioId",
                principalTable: "Cardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealMenu_Refeicao_RefeicaoId",
                table: "MealMenu",
                column: "RefeicaoId",
                principalTable: "Refeicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
