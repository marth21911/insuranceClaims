using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace insuranceClaims.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FName = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: false),
                    ZipCode = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "LostItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OldProduct = table.Column<string>(nullable: true),
                    Room = table.Column<string>(nullable: true),
                    QuantityL = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Tax = table.Column<decimal>(nullable: false),
                    Retail = table.Column<decimal>(nullable: false),
                    Depreciation = table.Column<decimal>(nullable: false),
                    ACV = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LostItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReplacedItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OriginalId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    Room = table.Column<string>(nullable: true),
                    QuantityBought = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    ReceiptName = table.Column<string>(nullable: true),
                    ReceiptData = table.Column<byte[]>(nullable: false),
                    Recovered = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplacedItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ReplacedItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LostItems_UserId",
                table: "LostItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacedItems_UserId",
                table: "ReplacedItems",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LostItems");

            migrationBuilder.DropTable(
                name: "ReplacedItems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
