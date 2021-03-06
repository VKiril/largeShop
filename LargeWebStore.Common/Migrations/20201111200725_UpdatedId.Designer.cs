﻿// <auto-generated />
using System;
using LargeWebStore.Common.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LargeWebStore.Common.Migrations
{
    [DbContext(typeof(LocalWebStoreContext))]
    [Migration("20201111200725_UpdatedId")]
    partial class UpdatedId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductImageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.Property<Guid>("TaxonId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TaxonId");

                    b.ToTable("ProductModel");
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductReviewModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductReviews");
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductTranslationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Locale")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductTranslations");
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductVariantModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Depth")
                        .HasColumnType("double precision");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<bool>("IsOnHand")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOnHold")
                        .HasColumnType("boolean");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<bool>("ShippingRequired")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("TaxCategoryId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Tracked")
                        .HasColumnType("boolean");

                    b.Property<Guid>("TranslationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.Property<double>("Width")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TaxCategoryId");

                    b.ToTable("ProductVariants");
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductVariantTranslationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Locale")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("ProductVariantId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductVariantId");

                    b.ToTable("ProductVariantTranslations");
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.TaxonModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("Parent")
                        .HasColumnType("uuid");

                    b.Property<int>("TreeLevel")
                        .HasColumnType("integer");

                    b.Property<Guid?>("TreeRoot")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Taxons");
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.TaxonTranslationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Locale")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.Property<Guid>("TaxonId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TaxonId");

                    b.ToTable("TaxonTranslations");
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Shipping.TaxCategoryModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("TaxCategoryModel");
                });

            modelBuilder.Entity("LargeWebStore.Common.Domain.Data.CustomerModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductImageModel", b =>
                {
                    b.HasOne("LargeWebStore.Common.Data.Models.Product.ProductModel", "Product")
                        .WithOne("Image")
                        .HasForeignKey("LargeWebStore.Common.Data.Models.Product.ProductImageModel", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductModel", b =>
                {
                    b.HasOne("LargeWebStore.Common.Data.Models.Product.TaxonModel", "Taxon")
                        .WithMany()
                        .HasForeignKey("TaxonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductReviewModel", b =>
                {
                    b.HasOne("LargeWebStore.Common.Data.Models.Product.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductTranslationModel", b =>
                {
                    b.HasOne("LargeWebStore.Common.Data.Models.Product.ProductModel", "Product")
                        .WithOne("Translation")
                        .HasForeignKey("LargeWebStore.Common.Data.Models.Product.ProductTranslationModel", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductVariantModel", b =>
                {
                    b.HasOne("LargeWebStore.Common.Data.Models.Product.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LargeWebStore.Common.Data.Models.Shipping.TaxCategoryModel", "TaxCategory")
                        .WithMany()
                        .HasForeignKey("TaxCategoryId");
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.ProductVariantTranslationModel", b =>
                {
                    b.HasOne("LargeWebStore.Common.Data.Models.Product.ProductVariantModel", "ProductVariant")
                        .WithMany()
                        .HasForeignKey("ProductVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LargeWebStore.Common.Data.Models.Product.TaxonTranslationModel", b =>
                {
                    b.HasOne("LargeWebStore.Common.Data.Models.Product.TaxonModel", "Taxon")
                        .WithMany()
                        .HasForeignKey("TaxonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
