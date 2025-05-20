using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeOdontoprevSprint3.Migrations
{
    /// <inheritdoc />
    public partial class AlterPacienteAdicionarCepNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cep",
                table: "Api_Dotnet_Pacientes",
                type: "NVARCHAR2(2000)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cep",
                table: "Api_Dotnet_Pacientes");
        }
    }
}
