﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TESTEGARAGENS_DR_WEBAPI.Migrations
{
    public partial class myinitMSSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormasPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Preco_1aHora = table.Column<string>(nullable: true),
                    Preco_HorasExtra = table.Column<string>(nullable: true),
                    Preco_Mensalista = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Garagem = table.Column<string>(nullable: true),
                    CarroPlaca = table.Column<string>(nullable: true),
                    CarroMarca = table.Column<string>(nullable: true),
                    CarroModelo = table.Column<string>(nullable: true),
                    DataHoraEntrada = table.Column<DateTime>(nullable: false),
                    DataHoraSaida = table.Column<DateTime>(nullable: false),
                    FormaPagamento = table.Column<string>(nullable: true),
                    PrecoTotal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FormasPagamento",
                columns: new[] { "Id", "Codigo", "Descricao" },
                values: new object[,]
                {
                    { 1, "DIN", "Dinheiro" },
                    { 2, "MEN", "Mensalista" },
                    { 3, "PIX", "Pix" },
                    { 4, "TAG", "Tag" },
                    { 5, "CDE", "Cartão de Débito" },
                    { 6, "CCR", "Cartão de Crédito" }
                });

            migrationBuilder.InsertData(
                table: "Garagens",
                columns: new[] { "Id", "Codigo", "Nome", "Preco_1aHora", "Preco_HorasExtra", "Preco_Mensalista" },
                values: new object[,]
                {
                    { 1, "EVO01", "Estamplaza Vila Olimpia", "40", "10", "550" },
                    { 2, "PLJK01", "Plaza JK", "35", "12", "380" },
                    { 3, "SZJK01", "Spazio JK", "30", "15", "350" },
                    { 4, "CSLU01", "Condominio São Luiz", "50", "12", "550" },
                    { 5, "COTO01", "Corporate Tower Itaim", "30", "12", "360" }
                });

            migrationBuilder.InsertData(
                table: "Passagens",
                columns: new[] { "Id", "CarroMarca", "CarroModelo", "CarroPlaca", "DataHoraEntrada", "DataHoraSaida", "FormaPagamento", "Garagem", "PrecoTotal" },
                values: new object[,]
                {
                    { 1, "Honda", "FIT", "ABC-0O12", new DateTime(2023, 9, 4, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 15, 15, 0, 0, DateTimeKind.Unspecified), "PIX", "EVO01", null },
                    { 2, "Toyota", "Yaris", "DKO-3927", new DateTime(2023, 9, 5, 8, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 5, 9, 55, 0, 0, DateTimeKind.Unspecified), "CCR", "EVO01", null },
                    { 3, "Fiat", "Argo", "SPE-9F42", new DateTime(2023, 9, 4, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 11, 20, 0, 0, DateTimeKind.Unspecified), "TAG", "EVO01", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormasPagamento");

            migrationBuilder.DropTable(
                name: "Garagens");

            migrationBuilder.DropTable(
                name: "Passagens");
        }
    }
}
