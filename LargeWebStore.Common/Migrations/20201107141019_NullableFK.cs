using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LargeWebStore.Common.Migrations
{
    public partial class NullableFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_TaxCategoryModel_TaxCategoryId",
                table: "ProductVariants");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaxCategoryId",
                table: "ProductVariants",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_TaxCategoryModel_TaxCategoryId",
                table: "ProductVariants",
                column: "TaxCategoryId",
                principalTable: "TaxCategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_TaxCategoryModel_TaxCategoryId",
                table: "ProductVariants");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaxCategoryId",
                table: "ProductVariants",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_TaxCategoryModel_TaxCategoryId",
                table: "ProductVariants",
                column: "TaxCategoryId",
                principalTable: "TaxCategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
