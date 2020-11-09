using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LargeWebStore.Common.Migrations
{
    public partial class Taxon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_TranslationId",
                table: "ProductVariants");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductVariantId",
                table: "ProductVariantTranslations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Taxons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TreeRoot = table.Column<Guid>(nullable: false),
                    Parent = table.Column<Guid>(nullable: false),
                    TreeLevel = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxonTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    TaxonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxonTranslations_Taxons_TaxonId",
                        column: x => x.TaxonId,
                        principalTable: "Taxons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantTranslations_ProductVariantId",
                table: "ProductVariantTranslations",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_TranslationId",
                table: "ProductVariants",
                column: "TranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonTranslations_TaxonId",
                table: "TaxonTranslations",
                column: "TaxonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariantTranslations_ProductVariants_ProductVariantId",
                table: "ProductVariantTranslations",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariantTranslations_ProductVariants_ProductVariantId",
                table: "ProductVariantTranslations");

            migrationBuilder.DropTable(
                name: "TaxonTranslations");

            migrationBuilder.DropTable(
                name: "Taxons");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariantTranslations_ProductVariantId",
                table: "ProductVariantTranslations");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_TranslationId",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "ProductVariantId",
                table: "ProductVariantTranslations");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_TranslationId",
                table: "ProductVariants",
                column: "TranslationId",
                unique: true);
        }
    }
}
