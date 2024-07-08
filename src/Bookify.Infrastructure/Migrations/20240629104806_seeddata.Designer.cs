﻿// <auto-generated />
using System;
using Bookify.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookify.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240629104806_seeddata")]
    partial class seeddata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Bookify.Domain.Apartments.Apartment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Amenities")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<DateTime?>("LastBookedOnUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.ToTable("apartments", (string)null);
                });

            modelBuilder.Entity("Bookify.Domain.Bookings.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ApartmentId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CancelledOnUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("CompletedOnUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ConfirmedOnUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("RejectedOnUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("bookings", (string)null);
                });

            modelBuilder.Entity("Bookify.Domain.Reviews.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ApartmentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("BookingId");

                    b.HasIndex("UserId");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("Bookify.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdentityId")
                        .IsUnique();

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ff747da5-6a82-4c40-b70e-732754b42c0d"),
                            Email = "Garry_Cummings@hotmail.com",
                            FirstName = "Kamryn",
                            IdentityId = "0b18a91e-cc77-6412-25f1-9cec70d454c5",
                            LastName = "Fadel"
                        },
                        new
                        {
                            Id = new Guid("3a462683-d48b-4d2d-9d20-5a0183c39306"),
                            Email = "Hazel.Lubowitz@hotmail.com",
                            FirstName = "Jesse",
                            IdentityId = "360c8a4b-1d35-976d-b2f9-4d34d614dfac",
                            LastName = "Krajcik"
                        },
                        new
                        {
                            Id = new Guid("5fb293bb-eae6-4221-b69f-de01ca0b4327"),
                            Email = "Judy76@yahoo.com",
                            FirstName = "Kelly",
                            IdentityId = "7259e892-ab51-b013-e0ed-29f4a7c5b7ed",
                            LastName = "Hartmann"
                        },
                        new
                        {
                            Id = new Guid("a3e1f014-3ae4-40ba-84b0-8991fc6f7aec"),
                            Email = "Jonathan37@gmail.com",
                            FirstName = "Myrtis",
                            IdentityId = "4f11324c-01d7-6b9e-84a2-58528d4f82d9",
                            LastName = "Fay"
                        },
                        new
                        {
                            Id = new Guid("394add29-add6-4dfc-b8bd-efa4a6da512e"),
                            Email = "Bryce18@gmail.com",
                            FirstName = "Kayley",
                            IdentityId = "ba1fb0c8-3fcd-4090-6493-4537ac53a9d3",
                            LastName = "Kuhlman"
                        },
                        new
                        {
                            Id = new Guid("19545c2e-473b-445b-8177-1c196ed34868"),
                            Email = "Maci_Schuppe63@gmail.com",
                            FirstName = "Dedric",
                            IdentityId = "b6e2d2c1-8abd-4382-be15-ebd4baac336f",
                            LastName = "Dickinson"
                        },
                        new
                        {
                            Id = new Guid("5a144b1a-ac54-464d-b9a5-f9aea5082b99"),
                            Email = "Hildegard_Lehner41@gmail.com",
                            FirstName = "Americo",
                            IdentityId = "fc898973-cf86-6fa1-cc8d-d3960c4ed481",
                            LastName = "Hickle"
                        },
                        new
                        {
                            Id = new Guid("48cc917a-7e50-4fe3-adf8-7e0601a1b12f"),
                            Email = "Jermain_Sawayn@gmail.com",
                            FirstName = "Sherman",
                            IdentityId = "7a1739fa-c1ef-5b63-0939-d052cc91af2c",
                            LastName = "Flatley"
                        },
                        new
                        {
                            Id = new Guid("4421064a-9dbe-4583-ab8e-199d9693acb3"),
                            Email = "Norval15@hotmail.com",
                            FirstName = "Blanca",
                            IdentityId = "c1fc7922-08af-6609-6585-b4eaf24dd0a4",
                            LastName = "Hilpert"
                        },
                        new
                        {
                            Id = new Guid("53966fa1-358f-4b8c-ba24-c8982a84ed41"),
                            Email = "Harley.Carter45@hotmail.com",
                            FirstName = "Tressa",
                            IdentityId = "06c4eb73-d434-e9f9-57c1-b639a2ef4608",
                            LastName = "Hamill"
                        });
                });

            modelBuilder.Entity("Bookify.Domain.Apartments.Apartment", b =>
                {
                    b.OwnsOne("Bookify.Domain.Apartments.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ApartmentId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("ApartmentId");

                            b1.ToTable("apartments");

                            b1.WithOwner()
                                .HasForeignKey("ApartmentId");
                        });

                    b.OwnsOne("Bookify.Domain.Shared.Money", "CleaningFee", b1 =>
                        {
                            b1.Property<Guid>("ApartmentId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("ApartmentId");

                            b1.ToTable("apartments");

                            b1.WithOwner()
                                .HasForeignKey("ApartmentId");
                        });

                    b.OwnsOne("Bookify.Domain.Shared.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("ApartmentId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("ApartmentId");

                            b1.ToTable("apartments");

                            b1.WithOwner()
                                .HasForeignKey("ApartmentId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("CleaningFee")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("Bookify.Domain.Bookings.Booking", b =>
                {
                    b.HasOne("Bookify.Domain.Apartments.Apartment", null)
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookify.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Bookify.Domain.Shared.Money", "AmenitiesUpCharge", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.OwnsOne("Bookify.Domain.Shared.Money", "CleaningFee", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.OwnsOne("Bookify.Domain.Shared.Money", "PriceForPeriod", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.OwnsOne("Bookify.Domain.Shared.Money", "TotalPrice", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.OwnsOne("Bookify.Domain.Bookings.DateRange", "Duration", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("End")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.Navigation("AmenitiesUpCharge")
                        .IsRequired();

                    b.Navigation("CleaningFee")
                        .IsRequired();

                    b.Navigation("Duration")
                        .IsRequired();

                    b.Navigation("PriceForPeriod")
                        .IsRequired();

                    b.Navigation("TotalPrice")
                        .IsRequired();
                });

            modelBuilder.Entity("Bookify.Domain.Reviews.Review", b =>
                {
                    b.HasOne("Bookify.Domain.Apartments.Apartment", null)
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookify.Domain.Bookings.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookify.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
