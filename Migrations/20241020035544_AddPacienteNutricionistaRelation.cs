using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutrIA.Migrations
{
    /// <inheritdoc />
    public partial class AddPacienteNutricionistaRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutricionista_Paciente_PacienteId",
                table: "Nutricionista");

            migrationBuilder.DropIndex(
                name: "IX_Nutricionista_PacienteId",
                table: "Nutricionista");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Nutricionista");

            migrationBuilder.AddColumn<int>(
                name: "NutricionistaId",
                table: "Paciente",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_NutricionistaId",
                table: "Paciente",
                column: "NutricionistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Nutricionista_NutricionistaId",
                table: "Paciente",
                column: "NutricionistaId",
                principalTable: "Nutricionista",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Nutricionista_NutricionistaId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_NutricionistaId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "NutricionistaId",
                table: "Paciente");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Nutricionista",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nutricionista_PacienteId",
                table: "Nutricionista",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutricionista_Paciente_PacienteId",
                table: "Nutricionista",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id");
        }
    }
}
