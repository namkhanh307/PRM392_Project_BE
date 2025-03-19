﻿// <auto-generated />
using System;
using FixItRight_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FixItRight_Infrastructure.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20250222082026_FixUserBalance")]
    partial class FixUserBalance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FixItRight_Domain.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MechanistId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("WorkingDate")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("WorkingTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MechanistId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ca4ae5b-c18d-4115-821f-3a28ed7a416f"),
                            Name = "Electricity"
                        },
                        new
                        {
                            Id = new Guid("150dcc51-3c46-4b48-bcbb-ec9bf217edfb"),
                            Name = "Plumber"
                        });
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("SenderId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
                            Active = true,
                            CategoryId = new Guid("9ca4ae5b-c18d-4115-821f-3a28ed7a416f"),
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8235),
                            Description = "Fridge Repair",
                            Image = "https://fixitright.blob.core.windows.net/fixitright/fridge.jpg",
                            Name = "Fridge Repair",
                            Price = 200000.0
                        },
                        new
                        {
                            Id = new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"),
                            Active = true,
                            CategoryId = new Guid("9ca4ae5b-c18d-4115-821f-3a28ed7a416f"),
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8262),
                            Description = "Air Condition Repair",
                            Image = "https://fixitright.blob.core.windows.net/fixitright/aircondition.jpg",
                            Name = "Air Condition Repair",
                            Price = 200000.0
                        },
                        new
                        {
                            Id = new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
                            Active = true,
                            CategoryId = new Guid("9ca4ae5b-c18d-4115-821f-3a28ed7a416f"),
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8268),
                            Description = "Washing Machine Repair",
                            Image = "https://fixitright.blob.core.windows.net/fixitright/washing.jpg",
                            Name = "Washing Machine Repair",
                            Price = 200000.0
                        },
                        new
                        {
                            Id = new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
                            Active = true,
                            CategoryId = new Guid("9ca4ae5b-c18d-4115-821f-3a28ed7a416f"),
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8271),
                            Description = "TV Repair",
                            Image = "https://fixitright.blob.core.windows.net/fixitright/tv.jpg",
                            Name = "TV Repair",
                            Price = 200000.0
                        },
                        new
                        {
                            Id = new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"),
                            Active = true,
                            CategoryId = new Guid("9ca4ae5b-c18d-4115-821f-3a28ed7a416f"),
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8273),
                            Description = "Microwave Repair",
                            Image = "https://fixitright.blob.core.windows.net/fixitright/microwave.jpg",
                            Name = "Microwave Repair",
                            Price = 200000.0
                        },
                        new
                        {
                            Id = new Guid("8f19e546-a41d-488a-85df-558af0caf391"),
                            Active = true,
                            CategoryId = new Guid("9ca4ae5b-c18d-4115-821f-3a28ed7a416f"),
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8275),
                            Description = "Oven Repair",
                            Image = "https://fixitright.blob.core.windows.net/fixitright/oven.jpg",
                            Name = "Oven Repair",
                            Price = 200000.0
                        },
                        new
                        {
                            Id = new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
                            Active = true,
                            CategoryId = new Guid("9ca4ae5b-c18d-4115-821f-3a28ed7a416f"),
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8278),
                            Description = "Dishwasher Repair",
                            Image = "https://fixitright.blob.core.windows.net/fixitright/dishwasher.jpg",
                            Name = "Dishwasher Repair",
                            Price = 200000.0
                        },
                        new
                        {
                            Id = new Guid("23814aee-13c1-41e4-a80d-bb8882eb00b2"),
                            Active = true,
                            CategoryId = new Guid("150dcc51-3c46-4b48-bcbb-ec9bf217edfb"),
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8280),
                            Description = "Pipe Repair",
                            Image = "https://fixitright.blob.core.windows.net/fixitright/pipe.jpg",
                            Name = "Pipe Repair",
                            Price = 200000.0
                        },
                        new
                        {
                            Id = new Guid("e21baed2-ac4d-4d91-af85-370f8ae5dd6c"),
                            Active = true,
                            CategoryId = new Guid("150dcc51-3c46-4b48-bcbb-ec9bf217edfb"),
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8284),
                            Description = "Sink Repair",
                            Image = "https://fixitright.blob.core.windows.net/fixitright/sink.jpg",
                            Name = "Sink Repair",
                            Price = 200000.0
                        },
                        new
                        {
                            Id = new Guid("f5c248ee-d9e6-44d3-9b16-117ceb616b9e"),
                            Active = true,
                            CategoryId = new Guid("150dcc51-3c46-4b48-bcbb-ec9bf217edfb"),
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8286),
                            Description = "Toilet Repair",
                            Image = "https://fixitright.blob.core.windows.net/fixitright/toilet.jpg",
                            Name = "Toilet Repair",
                            Price = 200000.0
                        },
                        new
                        {
                            Id = new Guid("3d32363b-dfa9-49ee-a6ac-8d3e7983294b"),
                            Active = true,
                            CategoryId = new Guid("150dcc51-3c46-4b48-bcbb-ec9bf217edfb"),
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8288),
                            Description = "Shower Repair",
                            Image = "https://fixitright.blob.core.windows.net/fixitright/shower.jpg",
                            Name = "Shower Repair",
                            Price = 200000.0
                        });
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("FixItRight_Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<DateOnly?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("CccdBack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CccdFront")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordResetTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "34e5bee4-75cb-423b-b8a3-58e5d0175989",
                            AccessFailedCount = 0,
                            Active = true,
                            Address = "TPHCM",
                            Avatar = "https://media.istockphoto.com/vectors/default-profile-picture-avatar-photo-placeholder-vector-illustration-vector-id1223671392?k=6&m=1223671392&s=170667a&w=0&h=zP3l7WJinOFaGb2i1F4g8IS2ylw0FlIaa6x3tP9sebU=",
                            Balance = 0.0,
                            Birthday = new DateOnly(2002, 1, 23),
                            ConcurrencyStamp = "c5ec63e3-7ed9-416f-9b4f-01076a9978b3",
                            CreatedAt = new DateTime(2025, 2, 22, 15, 20, 25, 987, DateTimeKind.Local).AddTicks(4840),
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            Fullname = "Admin",
                            Gender = "Male",
                            IsVerified = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEPSwcaGUHIHiSDsxlOsiVXigViHd3Wtm0Jaz9FKZb39GUObqZOqB1rIS1v6+BMDSxg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "419ed93a-a02a-4595-9aa2-79be41bf89fe",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a0bf18ce-48d8-4f97-820e-97b5af1974c8",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "b37d904e-16fb-4cda-8c3b-6f7f15f5819d",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = "bee3179d-722c-404b-95c7-d3ae5c260d40",
                            Name = "Mechanist",
                            NormalizedName = "MECHANIST"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "34e5bee4-75cb-423b-b8a3-58e5d0175989",
                            RoleId = "a0bf18ce-48d8-4f97-820e-97b5af1974c8"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Booking", b =>
                {
                    b.HasOne("FixItRight_Domain.Models.User", "Customer")
                        .WithMany("CustomerBookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FixItRight_Domain.Models.User", "Mechanist")
                        .WithMany("MechanistBookings")
                        .HasForeignKey("MechanistId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("FixItRight_Domain.Models.Service", "Service")
                        .WithMany("Bookings")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Mechanist");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Chat", b =>
                {
                    b.HasOne("FixItRight_Domain.Models.Booking", "Booking")
                        .WithMany("Chats")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FixItRight_Domain.Models.User", "Sender")
                        .WithMany("Chats")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Rating", b =>
                {
                    b.HasOne("FixItRight_Domain.Models.Booking", "Booking")
                        .WithOne("Rating")
                        .HasForeignKey("FixItRight_Domain.Models.Rating", "BookingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Service", b =>
                {
                    b.HasOne("FixItRight_Domain.Models.Category", "Category")
                        .WithMany("Services")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Transaction", b =>
                {
                    b.HasOne("FixItRight_Domain.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FixItRight_Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FixItRight_Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FixItRight_Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FixItRight_Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Booking", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Rating")
                        .IsRequired();
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Category", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("FixItRight_Domain.Models.Service", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("FixItRight_Domain.Models.User", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("CustomerBookings");

                    b.Navigation("MechanistBookings");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
