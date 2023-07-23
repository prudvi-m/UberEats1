﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UberEats.Models;

#nullable disable

namespace UberEats.Migrations
{
    [DbContext(typeof(UberContext))]
    partial class UberContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("UberEats.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Name = "Restaurant"
                        },
                        new
                        {
                            CategoryID = 2,
                            Name = "Grocery"
                        },
                        new
                        {
                            CategoryID = 3,
                            Name = "Alcohol"
                        },
                        new
                        {
                            CategoryID = 4,
                            Name = "Convienience"
                        },
                        new
                        {
                            CategoryID = 5,
                            Name = "Flower shop"
                        },
                        new
                        {
                            CategoryID = 6,
                            Name = "Pet Store"
                        },
                        new
                        {
                            CategoryID = 7,
                            Name = "retail"
                        });
                });

            modelBuilder.Entity("UberEats.Models.Driver", b =>
                {
                    b.Property<int>("DriverID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("DriverLicense")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DriverID");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("UberEats.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ItemCategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PartnerID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("ItemID");

                    b.HasIndex("ItemCategoryID");

                    b.HasIndex("PartnerID");

                    b.ToTable("Menu");

                    b.HasData(
                        new
                        {
                            ItemID = 1,
                            Description = "Traditional Delicious Sweet",
                            ItemCategoryID = 5,
                            Name = "Payasam",
                            PartnerID = 1,
                            Price = 5.2000000000000002
                        });
                });

            modelBuilder.Entity("UberEats.Models.ItemCategory", b =>
                {
                    b.Property<int>("ItemCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ItemCategoryID");

                    b.ToTable("MenuCategories");

                    b.HasData(
                        new
                        {
                            ItemCategoryID = 1,
                            Name = "Appetizer"
                        },
                        new
                        {
                            ItemCategoryID = 2,
                            Name = "Soup"
                        },
                        new
                        {
                            ItemCategoryID = 3,
                            Name = "Salad"
                        },
                        new
                        {
                            ItemCategoryID = 4,
                            Name = "Main Course"
                        },
                        new
                        {
                            ItemCategoryID = 5,
                            Name = "Dessert"
                        },
                        new
                        {
                            ItemCategoryID = 6,
                            Name = "Drink"
                        },
                        new
                        {
                            ItemCategoryID = 7,
                            Name = "Vegetarian"
                        });
                });

            modelBuilder.Entity("UberEats.Models.Partner", b =>
                {
                    b.Property<int>("PartnerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BusinessAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BusinessEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BusinessPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LogoImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PartnerID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Partners");

                    b.HasData(
                        new
                        {
                            PartnerID = 1,
                            BusinessAddress = "Chicago, 3001",
                            BusinessEmail = "intial@gmail.com",
                            BusinessName = "intial",
                            BusinessPhone = "123456",
                            CategoryID = 1,
                            LogoImage = ""
                        });
                });

            modelBuilder.Entity("UberEats.Models.Item", b =>
                {
                    b.HasOne("UberEats.Models.ItemCategory", "ItemCategory")
                        .WithMany()
                        .HasForeignKey("ItemCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UberEats.Models.Partner", null)
                        .WithMany("Menu")
                        .HasForeignKey("PartnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemCategory");
                });

            modelBuilder.Entity("UberEats.Models.Partner", b =>
                {
                    b.HasOne("UberEats.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("UberEats.Models.Partner", b =>
                {
                    b.Navigation("Menu");
                });
#pragma warning restore 612, 618
        }
    }
}
