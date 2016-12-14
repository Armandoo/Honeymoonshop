using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Honeymoonshop.Migrations
{
    public partial class product_database_uitbreiding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "merk",
                table: "Producten");

            migrationBuilder.CreateTable(
                name: "Kenmerken",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Productid = table.Column<int>(nullable: true),
                    naam = table.Column<string>(nullable: true),
                    neklijn = table.Column<string>(nullable: true),
                    silhouette = table.Column<string>(nullable: true),
                    stijl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kenmerken", x => x.id);
                    table.ForeignKey(
                        name: "FK_Kenmerken_Producten_Productid",
                        column: x => x.Productid,
                        principalTable: "Producten",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kleuren",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Productid = table.Column<int>(nullable: true),
                    kleur = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kleuren", x => x.id);
                    table.ForeignKey(
                        name: "FK_Kleuren_Producten_Productid",
                        column: x => x.Productid,
                        principalTable: "Producten",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Merken",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    merkNaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merken", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAfbeeldingen",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Productid = table.Column<int>(nullable: true),
                    bestandsNaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAfbeeldingen", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductAfbeeldingen_Producten_Productid",
                        column: x => x.Productid,
                        principalTable: "Producten",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "merkid",
                table: "Producten",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "omschrijving",
                table: "Producten",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producten_merkid",
                table: "Producten",
                column: "merkid");

            migrationBuilder.CreateIndex(
                name: "IX_Kenmerken_Productid",
                table: "Kenmerken",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_Kleuren_Productid",
                table: "Kleuren",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAfbeeldingen_Productid",
                table: "ProductAfbeeldingen",
                column: "Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_Producten_Merken_merkid",
                table: "Producten",
                column: "merkid",
                principalTable: "Merken",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producten_Merken_merkid",
                table: "Producten");

            migrationBuilder.DropIndex(
                name: "IX_Producten_merkid",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "merkid",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "omschrijving",
                table: "Producten");

            migrationBuilder.DropTable(
                name: "Kenmerken");

            migrationBuilder.DropTable(
                name: "Kleuren");

            migrationBuilder.DropTable(
                name: "Merken");

            migrationBuilder.DropTable(
                name: "ProductAfbeeldingen");

            migrationBuilder.AddColumn<string>(
                name: "merk",
                table: "Producten",
                nullable: true);
        }
    }
}
