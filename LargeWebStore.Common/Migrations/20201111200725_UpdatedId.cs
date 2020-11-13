using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LargeWebStore.Common.Migrations
{
    public partial class UpdatedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TreeRoot",
                table: "Taxons",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Parent",
                table: "Taxons",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "TaxonId",
                table: "ProductModel",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_TaxonId",
                table: "ProductModel",
                column: "TaxonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_Taxons_TaxonId",
                table: "ProductModel",
                column: "TaxonId",
                principalTable: "Taxons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_Taxons_TaxonId",
                table: "ProductModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductModel_TaxonId",
                table: "ProductModel");

            migrationBuilder.DropColumn(
                name: "TaxonId",
                table: "ProductModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "TreeRoot",
                table: "Taxons",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Parent",
                table: "Taxons",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
