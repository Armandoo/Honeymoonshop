using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Honeymoonshop.Migrations
{
    public partial class newkleur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kleuren_Producten_Productid",
                table: "Kleuren");

            migrationBuilder.DropIndex(
                name: "IX_Kleuren_Productid",
                table: "Kleuren");

            migrationBuilder.DropColumn(
                name: "categorie",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "Productid",
                table: "Kleuren");

            migrationBuilder.CreateTable(
                name: "ktKleurProduct",
                columns: table => new
                {
                    kleurId = table.Column<int>(nullable: false),
                    productId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ktKleurProduct", x => new { x.kleurId, x.productId });
                    table.ForeignKey(
                        name: "FK_ktKleurProduct_Kleuren_kleurId",
                        column: x => x.kleurId,
                        principalTable: "Kleuren",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ktKleurProduct_Producten_productId",
                        column: x => x.productId,
                        principalTable: "Producten",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "categorieid",
                table: "Producten",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producten_categorieid",
                table: "Producten",
                column: "categorieid");

            migrationBuilder.CreateIndex(
                name: "IX_ktKleurProduct_kleurId",
                table: "ktKleurProduct",
                column: "kleurId");

            migrationBuilder.CreateIndex(
                name: "IX_ktKleurProduct_productId",
                table: "ktKleurProduct",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producten_Category_categorieid",
                table: "Producten",
                column: "categorieid",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producten_Category_categorieid",
                table: "Producten");

            migrationBuilder.DropIndex(
                name: "IX_Producten_categorieid",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "categorieid",
                table: "Producten");

            migrationBuilder.DropTable(
                name: "ktKleurProduct");

            migrationBuilder.AddColumn<int>(
                name: "categorie",
                table: "Producten",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Productid",
                table: "Kleuren",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kleuren_Productid",
                table: "Kleuren",
                column: "Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_Kleuren_Producten_Productid",
                table: "Kleuren",
                column: "Productid",
                principalTable: "Producten",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
