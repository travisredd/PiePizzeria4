using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PiePizzeria.Migrations
{
    public partial class OverhaulOfImageToStoreDifferent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl",
                table: "Pie");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pie");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Pie",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LongDescription",
                table: "Pie",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Pie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageContentType",
                table: "Pie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Pie");

            migrationBuilder.DropColumn(
                name: "ImageContentType",
                table: "Pie");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Pie",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LongDescription",
                table: "Pie",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl",
                table: "Pie",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pie",
                nullable: false,
                defaultValue: "");
        }
    }
}
