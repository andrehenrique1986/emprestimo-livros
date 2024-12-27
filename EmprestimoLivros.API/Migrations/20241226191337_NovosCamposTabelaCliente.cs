using Microsoft.EntityFrameworkCore.Migrations;

namespace EmprestimoLivros.API.Migrations
{
    public partial class NovosCamposTabelaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cliente",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Cliente",
                newName: "cliNome");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Cliente",
                newName: "cliNumero");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Cliente",
                newName: "cliEndereco");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Cliente",
                newName: "cliTelefoneCelular");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "Cliente",
                newName: "cliCidade");

            migrationBuilder.AddColumn<string>(
                name: "cliBairro",
                table: "Cliente",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cliCPF",
                table: "Cliente",
                type: "varchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cliTelefoneFixo",
                table: "Cliente",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cliBairro",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "cliCPF",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "cliTelefoneFixo",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cliente",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "cliTelefoneCelular",
                table: "Cliente",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "cliNumero",
                table: "Cliente",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "cliNome",
                table: "Cliente",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "cliEndereco",
                table: "Cliente",
                newName: "Cidade");

            migrationBuilder.RenameColumn(
                name: "cliCidade",
                table: "Cliente",
                newName: "Bairro");
        }
    }
}
