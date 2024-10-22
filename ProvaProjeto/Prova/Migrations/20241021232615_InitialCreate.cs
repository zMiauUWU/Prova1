using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prova.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    cpf = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    valor = table.Column<double>(type: "REAL", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    mes = table.Column<int>(type: "INTEGER", nullable: false),
                    ano = table.Column<int>(type: "INTEGER", nullable: false),
                    funcionarioId = table.Column<int>(type: "INTEGER", nullable: true),
                    salarioBruto = table.Column<double>(type: "REAL", nullable: false),
                    impostoIrrf = table.Column<double>(type: "REAL", nullable: false),
                    impostoInss = table.Column<double>(type: "REAL", nullable: false),
                    impostoFgts = table.Column<double>(type: "REAL", nullable: false),
                    salarioLiquido = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folhas_Funcionarios_funcionarioId",
                        column: x => x.funcionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_funcionarioId",
                table: "Folhas",
                column: "funcionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
