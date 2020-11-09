using Microsoft.EntityFrameworkCore.Migrations;

namespace LargeWebStore.Common.Migrations
{
    public partial class AddTaxon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_ProductVariantTranslations_TranslationId",
                table: "ProductVariants");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_TranslationId",
                table: "ProductVariants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_TranslationId",
                table: "ProductVariants",
                column: "TranslationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_ProductVariantTranslations_TranslationId",
                table: "ProductVariants",
                column: "TranslationId",
                principalTable: "ProductVariantTranslations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
