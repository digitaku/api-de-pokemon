using Microsoft.EntityFrameworkCore.Migrations;

namespace api_de_pokemon.Migrations
{
    public partial class InitialCreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_abilities",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    effect_decription = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    is_hidden = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_abilities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_pokemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Alias = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Color = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Height = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Weight = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pokemon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    color = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_pokemon_abilities",
                columns: table => new
                {
                    AbilitiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pokemon_abilities", x => new { x.AbilitiesId, x.PokemonsId });
                    table.ForeignKey(
                        name: "FK_tb_pokemon_abilities_tb_abilities_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "tb_abilities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_pokemon_abilities_tb_pokemon_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "tb_pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_pokemon_types",
                columns: table => new
                {
                    PokemonsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pokemon_types", x => new { x.PokemonsId, x.TypesId });
                    table.ForeignKey(
                        name: "FK_tb_pokemon_types_tb_pokemon_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "tb_pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_pokemon_types_tb_types_TypesId",
                        column: x => x.TypesId,
                        principalTable: "tb_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_pokemon_abilities_PokemonsId",
                table: "tb_pokemon_abilities",
                column: "PokemonsId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pokemon_types_TypesId",
                table: "tb_pokemon_types",
                column: "TypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_pokemon_abilities");

            migrationBuilder.DropTable(
                name: "tb_pokemon_types");

            migrationBuilder.DropTable(
                name: "tb_abilities");

            migrationBuilder.DropTable(
                name: "tb_pokemon");

            migrationBuilder.DropTable(
                name: "tb_types");
        }
    }
}
