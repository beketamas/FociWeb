using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FociWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_647 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meccsek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fordulo = table.Column<int>(type: "INTEGER", nullable: false),
                    HazaGolok = table.Column<int>(type: "INTEGER", nullable: false),
                    VendegGolok = table.Column<int>(type: "INTEGER", nullable: false),
                    HazaiElsoFelidoGolok = table.Column<int>(type: "INTEGER", nullable: false),
                    VendegElsoFelidoGolok = table.Column<int>(type: "INTEGER", nullable: false),
                    HazaiCsapat = table.Column<string>(type: "TEXT", nullable: false),
                    VendegCsapat = table.Column<string>(type: "TEXT", nullable: false),
                    VegEredmeny1 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meccsek", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meccsek");
        }
    }
}
