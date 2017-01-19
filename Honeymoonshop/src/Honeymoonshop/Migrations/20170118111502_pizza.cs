using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Honeymoonshop.Migrations
{
    public partial class pizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Artikelnummer",
                table: "Producten",
                maxLength: 5,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "MerkNaam",
                table: "Merken",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Kleuren",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Telefoonnummer",
                table: "Klanten",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Kenmerken",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Category",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Artikelnummer",
                table: "Producten",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "MerkNaam",
                table: "Merken",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Kleuren",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Telefoonnummer",
                table: "Klanten",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Kenmerken",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Category",
                nullable: true);
        }
    }
}
