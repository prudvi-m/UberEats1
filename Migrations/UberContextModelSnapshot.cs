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

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DriverID");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            DriverID = 1,
                            Address = "address",
                            DateOfBirth = new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DriverLicense = "21342134",
                            Email = "sample@fgmailc.com",
                            FirstName = "fname",
                            LastName = "lname",
                            Phone = "123-123-1212",
                            PostCode = "12345-1234",
                            SSN = "123-12-1212",
                            Status = "New"
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

                    b.Property<string>("Status")
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
                            LogoImage = "",
                            Status = "New"
                        });
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
#pragma warning restore 612, 618
        }
    }
}
