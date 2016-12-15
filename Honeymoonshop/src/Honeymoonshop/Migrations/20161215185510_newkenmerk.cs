using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Honeymoonshop.Migrations
{
    public partial class newkenmerk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kenmerken_Producten_Productid",
                table: "Kenmerken");

            migrationBuilder.DropIndex(
                name: "IX_Kenmerken_Productid",
                table: "Kenmerken");

            migrationBuilder.DropColumn(
                name: "Productid",
                table: "Kenmerken");

            migrationBuilder.CreateTable(
                name: "Kenmerkproduct",
                columns: table => new
                {
                    kenmerkId = table.Column<int>(nullable: false),
                    productId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kenmerkproduct", x => new { x.kenmerkId, x.productId });
                    table.ForeignKey(
                        name: "FK_Kenmerkproduct_Kenmerken_kenmerkId",
                        column: x => x.kenmerkId,
                        principalTable: "Kenmerken",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kenmerkproduct_Producten_productId",
                        column: x => x.productId,
                        principalTable: "Producten",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kenmerkproduct_kenmerkId",
                table: "Kenmerkproduct",
                column: "kenmerkId");

            migrationBuilder.CreateIndex(
                name: "IX_Kenmerkproduct_productId",
                table: "Kenmerkproduct",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kenmerkproduct");

            migrationBuilder.AddColumn<int>(
                name: "Productid",
                table: "Kenmerken",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kenmerken_Productid",
                table: "Kenmerken",
                column: "Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_Kenmerken_Producten_Productid",
                table: "Kenmerken",
                column: "Productid",
                principalTable: "Producten",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
