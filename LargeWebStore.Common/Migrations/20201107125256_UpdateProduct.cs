using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LargeWebStore.Common.Migrations
{
    public partial class UpdateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnHand",
                table: "ProductVariants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnHold",
                table: "ProductVariants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TaxCategoryId",
                table: "ProductVariants",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TaxCategoryModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCategoryModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_TaxCategoryId",
                table: "ProductVariants",
                column: "TaxCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_TaxCategoryModel_TaxCategoryId",
                table: "ProductVariants",
                column: "TaxCategoryId",
                principalTable: "TaxCategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_TaxCategoryModel_TaxCategoryId",
                table: "ProductVariants");

            migrationBuilder.DropTable(
                name: "TaxCategoryModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_TaxCategoryId",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "IsOnHand",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "IsOnHold",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "TaxCategoryId",
                table: "ProductVariants");
        }
    }
}
