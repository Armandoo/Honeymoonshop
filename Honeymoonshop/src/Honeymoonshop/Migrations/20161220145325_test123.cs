using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Honeymoonshop.Migrations
{
    public partial class test123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAfbeeldingen_Producten_Productid",
                table: "ProductAfbeeldingen");

            migrationBuilder.DropIndex(
                name: "IX_ProductAfbeeldingen_Productid",
                table: "ProductAfbeeldingen");

            migrationBuilder.DropColumn(
                name: "Productid",
                table: "ProductAfbeeldingen");

            migrationBuilder.AddColumn<int>(
                name: "KleurproductkleurId",
                table: "ProductAfbeeldingen",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KleurproductproductId",
                table: "ProductAfbeeldingen",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "kleurImageid",
                table: "ProductAfbeeldingen",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAfbeeldingen_kleurImageid",
                table: "ProductAfbeeldingen",
                column: "kleurImageid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAfbeeldingen_KleurproductkleurId_KleurproductproductId",
                table: "ProductAfbeeldingen",
                columns: new[] { "KleurproductkleurId", "KleurproductproductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAfbeeldingen_Kleuren_kleurImageid",
                table: "ProductAfbeeldingen",
                column: "kleurImageid",
                principalTable: "Kleuren",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAfbeeldingen_ktKleurProduct_KleurproductkleurId_KleurproductproductId",
                table: "ProductAfbeeldingen",
                columns: new[] { "KleurproductkleurId", "KleurproductproductId" },
                principalTable: "ktKleurProduct",
                principalColumns: new[] { "kleurId", "productId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAfbeeldingen_Kleuren_kleurImageid",
                table: "ProductAfbeeldingen");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAfbeeldingen_ktKleurProduct_KleurproductkleurId_KleurproductproductId",
                table: "ProductAfbeeldingen");

            migrationBuilder.DropIndex(
                name: "IX_ProductAfbeeldingen_kleurImageid",
                table: "ProductAfbeeldingen");

            migrationBuilder.DropIndex(
                name: "IX_ProductAfbeeldingen_KleurproductkleurId_KleurproductproductId",
                table: "ProductAfbeeldingen");

            migrationBuilder.DropColumn(
                name: "KleurproductkleurId",
                table: "ProductAfbeeldingen");

            migrationBuilder.DropColumn(
                name: "KleurproductproductId",
                table: "ProductAfbeeldingen");

            migrationBuilder.DropColumn(
                name: "kleurImageid",
                table: "ProductAfbeeldingen");

            migrationBuilder.AddColumn<int>(
                name: "Productid",
                table: "ProductAfbeeldingen",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAfbeeldingen_Productid",
                table: "ProductAfbeeldingen",
                column: "Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAfbeeldingen_Producten_Productid",
                table: "ProductAfbeeldingen",
                column: "Productid",
                principalTable: "Producten",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
