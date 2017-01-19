using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Honeymoonshop.Migrations
{
    public partial class pizza123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afspraken_Klanten_klantid",
                table: "Afspraken");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAfbeeldingen_Producten_Productid",
                table: "ProductAfbeeldingen");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAfbeeldingen_ktKleurProduct_kleurproductkleurId_kleurproductproductId",
                table: "ProductAfbeeldingen");

            migrationBuilder.AlterColumn<string>(
                name: "Omschrijving",
                table: "Producten",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Afspraken_Klanten_KlantId",
                table: "Afspraken",
                column: "klantid",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAfbeeldingen_Producten_ProductId",
                table: "ProductAfbeeldingen",
                column: "Productid",
                principalTable: "Producten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAfbeeldingen_ktKleurProduct_KleurproductKleurId_KleurproductProductId",
                table: "ProductAfbeeldingen",
                columns: new[] { "kleurproductkleurId", "kleurproductproductId" },
                principalTable: "ktKleurProduct",
                principalColumns: new[] { "KleurId", "ProductId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "kleurproductproductId",
                table: "ProductAfbeeldingen",
                newName: "KleurproductProductId");

            migrationBuilder.RenameColumn(
                name: "kleurproductkleurId",
                table: "ProductAfbeeldingen",
                newName: "KleurproductKleurId");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "ProductAfbeeldingen",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "prijs",
                table: "Producten",
                newName: "Prijs");

            migrationBuilder.RenameColumn(
                name: "klantid",
                table: "Afspraken",
                newName: "KlantId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAfbeeldingen_kleurproductkleurId_kleurproductproductId",
                table: "ProductAfbeeldingen",
                newName: "IX_ProductAfbeeldingen_KleurproductKleurId_KleurproductProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAfbeeldingen_Productid",
                table: "ProductAfbeeldingen",
                newName: "IX_ProductAfbeeldingen_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Afspraken_klantid",
                table: "Afspraken",
                newName: "IX_Afspraken_KlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afspraken_Klanten_KlantId",
                table: "Afspraken");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAfbeeldingen_Producten_ProductId",
                table: "ProductAfbeeldingen");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAfbeeldingen_ktKleurProduct_KleurproductKleurId_KleurproductProductId",
                table: "ProductAfbeeldingen");

            migrationBuilder.AlterColumn<string>(
                name: "Omschrijving",
                table: "Producten",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Afspraken_Klanten_klantid",
                table: "Afspraken",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAfbeeldingen_Producten_Productid",
                table: "ProductAfbeeldingen",
                column: "ProductId",
                principalTable: "Producten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAfbeeldingen_ktKleurProduct_kleurproductkleurId_kleurproductproductId",
                table: "ProductAfbeeldingen",
                columns: new[] { "KleurproductKleurId", "KleurproductProductId" },
                principalTable: "ktKleurProduct",
                principalColumns: new[] { "KleurId", "ProductId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductAfbeeldingen",
                newName: "Productid");

            migrationBuilder.RenameColumn(
                name: "KleurproductProductId",
                table: "ProductAfbeeldingen",
                newName: "kleurproductproductId");

            migrationBuilder.RenameColumn(
                name: "KleurproductKleurId",
                table: "ProductAfbeeldingen",
                newName: "kleurproductkleurId");

            migrationBuilder.RenameColumn(
                name: "Prijs",
                table: "Producten",
                newName: "prijs");

            migrationBuilder.RenameColumn(
                name: "KlantId",
                table: "Afspraken",
                newName: "klantid");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAfbeeldingen_KleurproductKleurId_KleurproductProductId",
                table: "ProductAfbeeldingen",
                newName: "IX_ProductAfbeeldingen_kleurproductkleurId_kleurproductproductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAfbeeldingen_ProductId",
                table: "ProductAfbeeldingen",
                newName: "IX_ProductAfbeeldingen_Productid");

            migrationBuilder.RenameIndex(
                name: "IX_Afspraken_KlantId",
                table: "Afspraken",
                newName: "IX_Afspraken_klantid");
        }
    }
}
