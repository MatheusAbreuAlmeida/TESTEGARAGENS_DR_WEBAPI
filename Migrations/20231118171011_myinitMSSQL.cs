using System;
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
