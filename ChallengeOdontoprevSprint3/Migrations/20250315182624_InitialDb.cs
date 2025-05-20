using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeOdontoprevSprint3.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Api_Dotnet_Agendamentos",
                columns: table => new
                {
                    id_agendamento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    data_agendamento = table.Column<DateTime>(name: "data_agendamento ", type: "TIMESTAMP(7)", nullable: false),
                    data_atendimento = table.Column<DateTime>(name: "data_atendimento ", type: "TIMESTAMP(7)", nullable: false),
                    id_paciente = table.Column<int>(name: "id_paciente ", type: "NUMBER(10)", nullable: false),
                    id_dentista = table.Column<int>(name: "id_dentista  ", type: "NUMBER(10)", nullable: false),
                    id_clinica = table.Column<int>(name: "id_clinica  ", type: "NUMBER(10)", nullable: false),
                    id_tabela_preco = table.Column<int>(name: "id_tabela_preco  ", type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Api_Dotnet_Agendamentos", x => x.id_agendamento);
                });

            migrationBuilder.CreateTable(
                name: "Api_Dotnet_Clinicas",
                columns: table => new
                {
                    id_clinica = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    endereco = table.Column<string>(name: "endereco ", type: "NVARCHAR2(2000)", nullable: false),
                    id_dentista = table.Column<int>(name: "id_dentista ", type: "NUMBER(10)", nullable: false),
                    nome_clinica = table.Column<string>(name: "nome_clinica ", type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Api_Dotnet_Clinicas", x => x.id_clinica);
                });

            migrationBuilder.CreateTable(
                name: "Api_Dotnet_Contas_Pagar",
                columns: table => new
                {
                    id_conta_pagar = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_clinica = table.Column<int>(name: "id_clinica ", type: "NUMBER(10)", nullable: false),
                    valor = table.Column<double>(name: "valor ", type: "BINARY_DOUBLE", nullable: false),
                    data_emissao = table.Column<DateTime>(name: "data_emissao ", type: "TIMESTAMP(7)", nullable: false),
                    data_vencimento = table.Column<DateTime>(name: "data_vencimento  ", type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Api_Dotnet_Contas_Pagar", x => x.id_conta_pagar);
                });

            migrationBuilder.CreateTable(
                name: "Api_Dotnet_Contas_Receber",
                columns: table => new
                {
                    id_conta_receber = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_paciente = table.Column<int>(name: "id_paciente ", type: "NUMBER(10)", nullable: false),
                    valor = table.Column<double>(name: "valor ", type: "BINARY_DOUBLE", nullable: false),
                    data_emissao = table.Column<DateTime>(name: "data_emissao ", type: "TIMESTAMP(7)", nullable: false),
                    data_vencimento = table.Column<DateTime>(name: "data_vencimento  ", type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Api_Dotnet_Contas_Receber", x => x.id_conta_receber);
                });

            migrationBuilder.CreateTable(
                name: "Api_Dotnet_Dentistas",
                columns: table => new
                {
                    id_dentista = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cpf_cnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    numero_cro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    telefone = table.Column<string>(name: "telefone ", type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(name: "email  ", type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Api_Dotnet_Dentistas", x => x.id_dentista);
                });

            migrationBuilder.CreateTable(
                name: "Api_Dotnet_Fraudes",
                columns: table => new
                {
                    id_fraude = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    tipo_fraude = table.Column<string>(name: "tipo_fraude  ", type: "NVARCHAR2(2000)", nullable: false),
                    descricao = table.Column<string>(name: "descricao ", type: "NVARCHAR2(2000)", nullable: false),
                    id_paciente = table.Column<int>(name: "id_paciente ", type: "NUMBER(10)", nullable: false),
                    id_dentista = table.Column<int>(name: "id_dentista  ", type: "NUMBER(10)", nullable: false),
                    id_clinica = table.Column<int>(name: "id_clinica   ", type: "NUMBER(10)", nullable: false),
                    id_agendamento = table.Column<int>(name: "id_agendamento ", type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Api_Dotnet_Fraudes", x => x.id_fraude);
                });

            migrationBuilder.CreateTable(
                name: "Api_Dotnet_Pacientes",
                columns: table => new
                {
                    id_paciente = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cpf_cnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    tipo_paciente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Api_Dotnet_Pacientes", x => x.id_paciente);
                });

            migrationBuilder.CreateTable(
                name: "Api_Dotnet_Tabela_Precos",
                columns: table => new
                {
                    id_tabela_preco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_procedimento = table.Column<string>(name: "nome_procedimento ", type: "NVARCHAR2(2000)", nullable: false),
                    valor = table.Column<double>(name: "valor ", type: "BINARY_DOUBLE", nullable: false),
                    descricao = table.Column<string>(name: "descricao ", type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Api_Dotnet_Tabela_Precos", x => x.id_tabela_preco);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Api_Dotnet_Agendamentos");

            migrationBuilder.DropTable(
                name: "Api_Dotnet_Clinicas");

            migrationBuilder.DropTable(
                name: "Api_Dotnet_Contas_Pagar");

            migrationBuilder.DropTable(
                name: "Api_Dotnet_Contas_Receber");

            migrationBuilder.DropTable(
                name: "Api_Dotnet_Dentistas");

            migrationBuilder.DropTable(
                name: "Api_Dotnet_Fraudes");

            migrationBuilder.DropTable(
                name: "Api_Dotnet_Pacientes");

            migrationBuilder.DropTable(
                name: "Api_Dotnet_Tabela_Precos");
        }
    }
}
