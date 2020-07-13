using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB_SERVER.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ProfissionalId = table.Column<Guid>(nullable: false),
                    RestauranteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votacoes_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Votacoes_Restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votacoes_ProfissionalId",
                table: "Votacoes",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Votacoes_RestauranteId",
                table: "Votacoes",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Votacoes_Data_ProfissionalId_RestauranteId",
                table: "Votacoes",
                columns: new[] { "Data", "ProfissionalId", "RestauranteId" },
                unique: true);
            migrationBuilder.Sql(@"
                    INSERT INTO Profissionais (Id, Nome)
                            VALUES  (NEWID(), 'Profissional 1'),
                                    (NEWID(), 'Profissional 2'),
                                    (NEWID(), 'Profissional 3'),
                                    (NEWID(), 'Profissional 4'),
                                    (NEWID(), 'Profissional 5'),
                                    (NEWID(), 'Profissional 6');
                    INSERT INTO Restaurantes (Id, Nome)
                            VALUES  (NEWID(), 'Restaurante 1'),
                                    (NEWID(), 'Restaurante 2'),
                                    (NEWID(), 'Restaurante 3'),
                                    (NEWID(), 'Restaurante 4'),
                                    (NEWID(), 'Restaurante 5'),
                                    (NEWID(), 'Restaurante 6');

                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votacoes");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Restaurantes");
        }
    }
}
