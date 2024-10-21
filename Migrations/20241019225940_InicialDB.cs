using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutrIA.Migrations
{
    /// <inheritdoc />
    public partial class InicialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sexo",
                table: "Pacientes",
                newName: "Sexo");

            migrationBuilder.RenameColumn(
                name: "peso",
                table: "Pacientes",
                newName: "Peso");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Pacientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Pacientes",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "altura",
                table: "Pacientes",
                newName: "Altura");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Pacientes",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Notas",
                table: "Pacientes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "Pacientes",
                newName: "sexo");

            migrationBuilder.RenameColumn(
                name: "Peso",
                table: "Pacientes",
                newName: "peso");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Pacientes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Pacientes",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Altura",
                table: "Pacientes",
                newName: "altura");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pacientes",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "Notas",
                table: "Pacientes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
