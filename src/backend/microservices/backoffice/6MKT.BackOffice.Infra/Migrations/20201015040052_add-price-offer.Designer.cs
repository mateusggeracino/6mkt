﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _6MKT.BackOffice.Infra.Context;

namespace _6MKT.BackOffice.Infra.Migrations
{
    [DbContext(typeof(MktContext))]
    [Migration("20201015040052_add-price-offer")]
    partial class addpriceoffer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.AddressEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("CreatedId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("ModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Address","backoffice");
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.BusinessEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("CreatedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("IdentityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("ModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("RegisteredNumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("TradeName")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Business","backoffice");
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.BusinessSubCategory", b =>
                {
                    b.Property<long>("SubCategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("BusinessId")
                        .HasColumnType("bigint");

                    b.HasKey("SubCategoryId", "BusinessId");

                    b.HasIndex("BusinessId");

                    b.ToTable("BusinessSubCategory","backoffice");
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.CategoryEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("CreatedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("ModifiedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Category","backoffice");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Casa, Móveis e Decoração"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Celulares e Telefones"
                        },
                        new
                        {
                            Id = 3L,
                            Description = "Games"
                        });
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.NaturalPersonEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("CreatedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("IdentityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("ModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("SocialNumber")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("NaturalPerson","backoffice");
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.OfferEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BusinessId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("CreatedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("ModifiedId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("PurchaseId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("Offer","backoffice");
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.PurchaseCompletedEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("CreatedId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("ModifiedId")
                        .HasColumnType("bigint");

                    b.Property<long>("OfferId")
                        .HasColumnType("bigint");

                    b.Property<long>("PurchaseId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OfferId")
                        .IsUnique();

                    b.HasIndex("PurchaseId")
                        .IsUnique();

                    b.ToTable("PurchaseCompleted","backoffice");
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.PurchaseEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AveragePrice")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("CreatedId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("ModifiedId")
                        .HasColumnType("bigint");

                    b.Property<long>("NaturalPersonId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("SubCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("NaturalPersonId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Purchase","backoffice");
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.SubCategoryEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("CreatedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("ModifiedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory","backoffice");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CategoryId = 1L,
                            Description = "Banheiros"
                        },
                        new
                        {
                            Id = 2L,
                            CategoryId = 1L,
                            Description = "Colchões e Camas Box"
                        },
                        new
                        {
                            Id = 3L,
                            CategoryId = 1L,
                            Description = "Cortinas e Acessórios"
                        },
                        new
                        {
                            Id = 4L,
                            CategoryId = 1L,
                            Description = "Móveis para Casa"
                        },
                        new
                        {
                            Id = 5L,
                            CategoryId = 2L,
                            Description = "Acessórios para Celulares"
                        },
                        new
                        {
                            Id = 6L,
                            CategoryId = 2L,
                            Description = "Celulares e Smartphones"
                        },
                        new
                        {
                            Id = 7L,
                            CategoryId = 2L,
                            Description = "Tarifadores e Cabines"
                        },
                        new
                        {
                            Id = 8L,
                            CategoryId = 3L,
                            Description = "Consoles"
                        },
                        new
                        {
                            Id = 9L,
                            CategoryId = 3L,
                            Description = "Peças para Consoles"
                        },
                        new
                        {
                            Id = 10L,
                            CategoryId = 3L,
                            Description = "Acessórios para PC Gaming"
                        },
                        new
                        {
                            Id = 11L,
                            CategoryId = 3L,
                            Description = "Video Games"
                        });
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.BusinessEntity", b =>
                {
                    b.HasOne("_6MKT.BackOffice.Domain.Entities.AddressEntity", "Address")
                        .WithOne()
                        .HasForeignKey("_6MKT.BackOffice.Domain.Entities.BusinessEntity", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.BusinessSubCategory", b =>
                {
                    b.HasOne("_6MKT.BackOffice.Domain.Entities.BusinessEntity", "Business")
                        .WithMany("SubCategories")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_6MKT.BackOffice.Domain.Entities.SubCategoryEntity", "SubCategory")
                        .WithMany("Businesses")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.NaturalPersonEntity", b =>
                {
                    b.HasOne("_6MKT.BackOffice.Domain.Entities.AddressEntity", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.OfferEntity", b =>
                {
                    b.HasOne("_6MKT.BackOffice.Domain.Entities.BusinessEntity", "Business")
                        .WithMany("Offers")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_6MKT.BackOffice.Domain.Entities.PurchaseEntity", "Purchase")
                        .WithMany("Offers")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.PurchaseCompletedEntity", b =>
                {
                    b.HasOne("_6MKT.BackOffice.Domain.Entities.OfferEntity", "Offer")
                        .WithOne()
                        .HasForeignKey("_6MKT.BackOffice.Domain.Entities.PurchaseCompletedEntity", "OfferId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("_6MKT.BackOffice.Domain.Entities.PurchaseEntity", "Purchase")
                        .WithOne()
                        .HasForeignKey("_6MKT.BackOffice.Domain.Entities.PurchaseCompletedEntity", "PurchaseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.PurchaseEntity", b =>
                {
                    b.HasOne("_6MKT.BackOffice.Domain.Entities.NaturalPersonEntity", "NaturalPerson")
                        .WithMany("Purchases")
                        .HasForeignKey("NaturalPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_6MKT.BackOffice.Domain.Entities.SubCategoryEntity", "SubCategory")
                        .WithMany("Purchases")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_6MKT.BackOffice.Domain.Entities.SubCategoryEntity", b =>
                {
                    b.HasOne("_6MKT.BackOffice.Domain.Entities.CategoryEntity", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
