using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutrIA.Migrations
{
    /// <inheritdoc />
    public partial class CreateUsuariosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "SenhaHash",
                table: "Usuario",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Nutricionista",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nutricionista_UsuarioId",
                table: "Nutricionista",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutricionista_Usuario_UsuarioId",
                table: "Nutricionista",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutricionista_Usuario_UsuarioId",
                table: "Nutricionista");

            migrationBuilder.DropIndex(
                name: "IX_Nutricionista_UsuarioId",
                table: "Nutricionista");

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Nutricionista");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Usuario",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Usuario",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
