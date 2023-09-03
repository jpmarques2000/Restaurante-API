using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteAPI.Migrations
{
    /// <inheritdoc />
    public partial class Segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardapioRefeicao_Cardapio_CardapioId",
                table: "CardapioRefeicao");

            migrationBuilder.DropForeignKey(
                name: "FK_CardapioRefeicao_Refeicao_RefeicaoId",
                table: "CardapioRefeicao");

            migrationBuilder.DropTable(
                name: "PedidoRefeicao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardapioRefeicao",
                table: "CardapioRefeicao");

            migrationBuilder.DropIndex(
                name: "IX_CardapioRefeicao_RefeicaoId",
                table: "CardapioRefeicao");

            migrationBuilder.RenameColumn(
                name: "RefeicaoId",
                table: "CardapioRefeicao",
                newName: "refeicaoId");

            migrationBuilder.RenameColumn(
                name: "CardapioId",
                table: "CardapioRefeicao",
                newName: "cardapioId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CardapioRefeicao",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardapioRefeicao",
                table: "CardapioRefeicao",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MealMenu",
                columns: table => new
                {
                    CardapioId = table.Column<int>(type: "int", nullable: false),
                    RefeicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealMenu", x => new { x.CardapioId, x.RefeicaoId });
                    table.ForeignKey(
                        name: "FK_MealMenu_Cardapio_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "Cardapio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealMenu_Refeicao_RefeicaoId",
                        column: x => x.RefeicaoId,
                        principalTable: "Refeicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealOrder",
                columns: table => new
                {
                    PedidosId = table.Column<int>(type: "int", nullable: false),
                    RefeicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOrder", x => new { x.PedidosId, x.RefeicaoId });
                    table.ForeignKey(
                        name: "FK_MealOrder_Pedido_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOrder_Refeicao_RefeicaoId",
                        column: x => x.RefeicaoId,
                        principalTable: "Refeicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealMenu_RefeicaoId",
                table: "MealMenu",
                column: "RefeicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOrder_RefeicaoId",
                table: "MealOrder",
                column: "RefeicaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealMenu");

            migrationBuilder.DropTable(
                name: "MealOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardapioRefeicao",
                table: "CardapioRefeicao");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CardapioRefeicao");

            migrationBuilder.RenameColumn(
                name: "refeicaoId",
                table: "CardapioRefeicao",
                newName: "RefeicaoId");

            migrationBuilder.RenameColumn(
                name: "cardapioId",
                table: "CardapioRefeicao",
                newName: "CardapioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardapioRefeicao",
                table: "CardapioRefeicao",
                columns: new[] { "CardapioId", "RefeicaoId" });

            migrationBuilder.CreateTable(
                name: "PedidoRefeicao",
                columns: table => new
                {
                    PedidosId = table.Column<int>(type: "int", nullable: false),
                    RefeicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoRefeicao", x => new { x.PedidosId, x.RefeicaoId });
                    table.ForeignKey(
                        name: "FK_PedidoRefeicao_Pedido_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoRefeicao_Refeicao_RefeicaoId",
                        column: x => x.RefeicaoId,
                        principalTable: "Refeicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardapioRefeicao_RefeicaoId",
                table: "CardapioRefeicao",
                column: "RefeicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoRefeicao_RefeicaoId",
                table: "PedidoRefeicao",
                column: "RefeicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardapioRefeicao_Cardapio_CardapioId",
                table: "CardapioRefeicao",
                column: "CardapioId",
                principalTable: "Cardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardapioRefeicao_Refeicao_RefeicaoId",
                table: "CardapioRefeicao",
                column: "RefeicaoId",
                principalTable: "Refeicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
