using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Repository.Migrations
{
    public partial class Migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_banco",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_banco = table.Column<string>(type: "varchar(100)", nullable: false),
                    codigo_banco = table.Column<string>(type: "varchar(40)", nullable: false),
                    percentual_juros = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_banco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_boleto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_pagador = table.Column<string>(type: "varchar(100)", nullable: false),
                    cpfcnpj_pagador = table.Column<string>(type: "varchar(11)", nullable: false),
                    nome_beneficiario = table.Column<string>(type: "varchar(100)", nullable: false),
                    cpfcnpj_beneficiario = table.Column<string>(type: "varchar(11)", nullable: false),
                    valor = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    observacao = table.Column<string>(type: "varchar(100)", nullable: false),
                    banco_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_boleto", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_banco");

            migrationBuilder.DropTable(
                name: "tb_boleto");
        }
    }
}
