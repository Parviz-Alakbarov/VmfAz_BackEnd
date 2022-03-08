﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(VmfAzContext))]
    [Migration("20220308065047_SettingTableCreated")]
    partial class SettingTableCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(500)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(500)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Core.Entities.Concrete.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Core.Entities.Concrete.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("OperationClaimId");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Entities.Concrete.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PosterImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Entities.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("DiscountPercent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProductBeltColorId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductBeltTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductCaseMaterialId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductCaseShapeId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductCaseSizeId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductDialColorId")
                        .HasColumnType("int");

                    b.Property<int>("ProductFunctionalityId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductGlassTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductMechanismId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductStyleId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductWaterResistanceId")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ToolCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<decimal>("WarrantyLimit")
                        .HasColumnType("decimal(3,1)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CountryId");

                    b.HasIndex("GenderId");

                    b.HasIndex("ProductBeltColorId");

                    b.HasIndex("ProductBeltTypeId");

                    b.HasIndex("ProductCaseMaterialId");

                    b.HasIndex("ProductCaseShapeId");

                    b.HasIndex("ProductCaseSizeId");

                    b.HasIndex("ProductDialColorId");

                    b.HasIndex("ProductFunctionalityId");

                    b.HasIndex("ProductGlassTypeId");

                    b.HasIndex("ProductMechanismId");

                    b.HasIndex("ProductStyleId");

                    b.HasIndex("ProductWaterResistanceId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HexValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductBeltType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductBeltTypes");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductCaseMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCaseMaterials");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductCaseShape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Shape")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCaseShapes");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductCaseSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCaseSizes");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductFunctionality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductFunctionalities");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductGlassType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductGlassTypes");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductMechanism", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductMechanisms");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductStyles");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductWaterResistance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ResistanceValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductWaterResistances");
                });

            modelBuilder.Entity("Entities.Concrete.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Entities.Concrete.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Core.Entities.Concrete.AppUser", b =>
                {
                    b.HasOne("Core.Entities.Concrete.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Concrete.Country", "Country")
                        .WithMany("AppUsers")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.Entities.Concrete.City", b =>
                {
                    b.HasOne("Core.Entities.Concrete.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.HasOne("Core.Entities.Concrete.AppUser", "AppUser")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Concrete.OperationClaim", "OperationClaim")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("OperationClaim");
                });

            modelBuilder.Entity("Entities.Concrete.Product", b =>
                {
                    b.HasOne("Entities.Concrete.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Concrete.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Entities.Concrete.ProductEntries.Gender", "Gender")
                        .WithMany("Products")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.ProductEntries.Color", "ProductBeltColor")
                        .WithMany("ProductsBelt")
                        .HasForeignKey("ProductBeltColorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Entities.Concrete.ProductEntries.ProductBeltType", "ProductBeltType")
                        .WithMany("Products")
                        .HasForeignKey("ProductBeltTypeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Entities.Concrete.ProductEntries.ProductCaseMaterial", "ProductCaseMaterial")
                        .WithMany("Products")
                        .HasForeignKey("ProductCaseMaterialId");

                    b.HasOne("Entities.Concrete.ProductEntries.ProductCaseShape", "ProductCaseShape")
                        .WithMany("Products")
                        .HasForeignKey("ProductCaseShapeId");

                    b.HasOne("Entities.Concrete.ProductEntries.ProductCaseSize", "ProductCaseSize")
                        .WithMany("Products")
                        .HasForeignKey("ProductCaseSizeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Entities.Concrete.ProductEntries.Color", "ProductDialColor")
                        .WithMany("ProductsDial")
                        .HasForeignKey("ProductDialColorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Entities.Concrete.ProductEntries.ProductFunctionality", null)
                        .WithMany("Products")
                        .HasForeignKey("ProductFunctionalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.ProductEntries.ProductGlassType", "ProductGlassType")
                        .WithMany("Products")
                        .HasForeignKey("ProductGlassTypeId");

                    b.HasOne("Entities.Concrete.ProductEntries.ProductMechanism", "ProductMechanism")
                        .WithMany("Products")
                        .HasForeignKey("ProductMechanismId");

                    b.HasOne("Entities.Concrete.ProductEntries.ProductStyle", "ProductStyle")
                        .WithMany("Products")
                        .HasForeignKey("ProductStyleId");

                    b.HasOne("Entities.Concrete.ProductEntries.ProductWaterResistance", "ProductWaterResistance")
                        .WithMany("Products")
                        .HasForeignKey("ProductWaterResistanceId");

                    b.Navigation("Brand");

                    b.Navigation("Country");

                    b.Navigation("Gender");

                    b.Navigation("ProductBeltColor");

                    b.Navigation("ProductBeltType");

                    b.Navigation("ProductCaseMaterial");

                    b.Navigation("ProductCaseShape");

                    b.Navigation("ProductCaseSize");

                    b.Navigation("ProductDialColor");

                    b.Navigation("ProductGlassType");

                    b.Navigation("ProductMechanism");

                    b.Navigation("ProductStyle");

                    b.Navigation("ProductWaterResistance");
                });

            modelBuilder.Entity("Entities.Concrete.ProductImage", b =>
                {
                    b.HasOne("Entities.Concrete.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Core.Entities.Concrete.AppUser", b =>
                {
                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concrete.Country", b =>
                {
                    b.Navigation("AppUsers");

                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Entities.Concrete.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Concrete.Product", b =>
                {
                    b.Navigation("ProductImages");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.Color", b =>
                {
                    b.Navigation("ProductsBelt");

                    b.Navigation("ProductsDial");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.Gender", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductBeltType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductCaseMaterial", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductCaseShape", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductCaseSize", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductFunctionality", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductGlassType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductMechanism", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductStyle", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Concrete.ProductEntries.ProductWaterResistance", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
