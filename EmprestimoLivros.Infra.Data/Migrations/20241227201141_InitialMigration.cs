using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmprestimoLivros.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CliCpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CliNome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CliEndereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CliCidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CliBairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CliNumero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CliTelefoneCelular = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CliTelefoneFixo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LivroAutor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LivroEditora = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LivroAnoPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivroEdicao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LceIdCliente = table.Column<int>(type: "int", nullable: false),
                    LceIdLivro = table.Column<int>(type: "int", nullable: false),
                    LceDataEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LceDataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LceEntregue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Cliente_LceIdCliente",
                        column: x => x.LceIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emprestimo_Livro_LceIdLivro",
                        column: x => x.LceIdLivro,
                        principalTable: "Livro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_LceIdCliente",
                table: "Emprestimo",
                column: "LceIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_LceIdLivro",
                table: "Emprestimo",
                column: "LceIdLivro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
