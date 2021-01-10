using Microsoft.EntityFrameworkCore.Migrations;

namespace Covaciu_Carla_Proiect1.Migrations
{
    public partial class LaptopCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "Laptop",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LaptopCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaptopID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LaptopCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaptopCategory_Laptop_LaptopID",
                        column: x => x.LaptopID,
                        principalTable: "Laptop",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laptop_StoreID",
                table: "Laptop",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_LaptopCategory_CategoryID",
                table: "LaptopCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_LaptopCategory_LaptopID",
                table: "LaptopCategory",
                column: "LaptopID");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptop_Store_StoreID",
                table: "Laptop",
                column: "StoreID",
                principalTable: "Store",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptop_Store_StoreID",
                table: "Laptop");

            migrationBuilder.DropTable(
                name: "LaptopCategory");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Laptop_StoreID",
                table: "Laptop");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Laptop");
        }
    }
}
