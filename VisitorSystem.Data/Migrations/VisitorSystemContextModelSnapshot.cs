﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VisitorSystem.Data.Concrete.EntityFramework.Contexts;

namespace VisitorSystem.Data.Migrations
{
    [DbContext(typeof(VisitorSystemContext))]
    partial class VisitorSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<long>("CountactNo")
                        .HasMaxLength(7)
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountactNo = 4443636L,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2021, 12, 2, 10, 17, 38, 153, DateTimeKind.Local).AddTicks(3840),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2021, 12, 2, 10, 17, 38, 153, DateTimeKind.Local).AddTicks(3895),
                            Name = "Bilgi Sistemleri Dairesi Başkanlığı"
                        },
                        new
                        {
                            Id = 2,
                            CountactNo = 4446666L,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2021, 12, 2, 10, 17, 38, 153, DateTimeKind.Local).AddTicks(3938),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2021, 12, 2, 10, 17, 38, 153, DateTimeKind.Local).AddTicks(3944),
                            Name = "Ağaçlandırma  Dairesi Başkanlığı"
                        },
                        new
                        {
                            Id = 3,
                            CountactNo = 4440606L,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2021, 12, 2, 10, 17, 38, 153, DateTimeKind.Local).AddTicks(3963),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2021, 12, 2, 10, 17, 38, 153, DateTimeKind.Local).AddTicks(3969),
                            Name = "Hukuk Müşavirliği"
                        },
                        new
                        {
                            Id = 4,
                            CountactNo = 4443362L,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2021, 12, 2, 10, 17, 38, 153, DateTimeKind.Local).AddTicks(3988),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2021, 12, 2, 10, 17, 38, 153, DateTimeKind.Local).AddTicks(3993),
                            Name = "Destek Hizmetleri  Dairesi Başkanlığı"
                        },
                        new
                        {
                            Id = 5,
                            CountactNo = 4448888L,
                            CreatedByName = "InitialCreate",
                            CreatedDate = new DateTime(2021, 12, 2, 10, 17, 38, 153, DateTimeKind.Local).AddTicks(4011),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreate",
                            ModifiedDate = new DateTime(2021, 12, 2, 10, 17, 38, 153, DateTimeKind.Local).AddTicks(4017),
                            Name = "Teftiş Kurulu Başkanlığı"
                        });
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "41db8627-cd4d-44cb-a5a6-2acd5c14c64a",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "6868121f-18e0-44de-bd9c-376e7d49e6f7",
                            Name = "Personal",
                            NormalizedName = "PERSONAL"
                        });
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6490beba-9e72-4af5-ab86-96f759725c22",
                            Email = "adminuser@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINUSER@GMAIL.COM",
                            NormalizedUserName = "ADMINUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEBCw7stA3rGKh57w1ACKUGxDZZmW12mJwlpU34J41m1hruOAMiaU2OnnioO2qv8Kvg==",
                            PhoneNumber = "5555555",
                            PhoneNumberConfirmed = true,
                            Picture = "defaultUser.png",
                            SecurityStamp = "d2da8cb0-c5c9-4d1d-8f27-4b02976dbf35",
                            TwoFactorEnabled = false,
                            UserName = "AdminUser"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4c8671f6-e89a-423c-8526-32e8d1cf681f",
                            Email = "personaluser@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "PERSONALUSER@GMAIL.COM",
                            NormalizedUserName = "PERSONALUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEHcmIMBj/8lj9M9pkYV138VEe2qdBSl3y9C5XuoQiMgaamB42L+eZkJD2to8zFDHAA==",
                            PhoneNumber = "6666666",
                            PhoneNumberConfirmed = true,
                            Picture = "defaultUser.png",
                            SecurityStamp = "b0736506-0435-44cf-8b92-baf7aeb8f023",
                            TwoFactorEnabled = false,
                            UserName = "PersonalUser"
                        });
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.UserToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExit")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Visitors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1999, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ContactNo = "11144445555",
                            CreatedByName = "IntinialCreated",
                            CreatedDate = new DateTime(2021, 12, 2, 10, 17, 38, 137, DateTimeKind.Local).AddTicks(582),
                            DepartmentId = 1,
                            EnterDate = new DateTime(2021, 12, 2, 10, 17, 38, 136, DateTimeKind.Local).AddTicks(4170),
                            FirstName = "Alper",
                            IsActive = true,
                            IsDeleted = false,
                            IsExit = false,
                            LastName = "Tunga",
                            ModifiedByName = "IntinialCreated",
                            ModifiedDate = new DateTime(2021, 12, 2, 10, 17, 38, 137, DateTimeKind.Local).AddTicks(3196),
                            OutDate = new DateTime(1999, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TcNo = "55555555555"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1999, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ContactNo = "22244445555",
                            CreatedByName = "IntinialCreated",
                            CreatedDate = new DateTime(2021, 12, 2, 10, 17, 38, 137, DateTimeKind.Local).AddTicks(5918),
                            DepartmentId = 2,
                            EnterDate = new DateTime(2021, 12, 2, 10, 17, 38, 137, DateTimeKind.Local).AddTicks(5907),
                            FirstName = "Engin",
                            IsActive = true,
                            IsDeleted = false,
                            IsExit = false,
                            LastName = "Demiroğ",
                            ModifiedByName = "IntinialCreated",
                            ModifiedDate = new DateTime(2021, 12, 2, 10, 17, 38, 137, DateTimeKind.Local).AddTicks(5924),
                            OutDate = new DateTime(1999, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TcNo = "11155555551"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1999, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ContactNo = "33344445555",
                            CreatedByName = "IntinialCreated",
                            CreatedDate = new DateTime(2021, 12, 2, 10, 17, 38, 137, DateTimeKind.Local).AddTicks(5954),
                            DepartmentId = 3,
                            EnterDate = new DateTime(2021, 12, 2, 10, 17, 38, 137, DateTimeKind.Local).AddTicks(5946),
                            FirstName = "Ayşe",
                            IsActive = true,
                            IsDeleted = false,
                            IsExit = false,
                            LastName = "Yılmaz",
                            ModifiedByName = "IntinialCreated",
                            ModifiedDate = new DateTime(2021, 12, 2, 10, 17, 38, 137, DateTimeKind.Local).AddTicks(5960),
                            OutDate = new DateTime(1999, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TcNo = "22225555555"
                        });
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.RoleClaim", b =>
                {
                    b.HasOne("VisitorSystem.Entities.Concrete.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.UserClaim", b =>
                {
                    b.HasOne("VisitorSystem.Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.UserLogin", b =>
                {
                    b.HasOne("VisitorSystem.Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.UserRole", b =>
                {
                    b.HasOne("VisitorSystem.Entities.Concrete.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisitorSystem.Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.UserToken", b =>
                {
                    b.HasOne("VisitorSystem.Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.Visitor", b =>
                {
                    b.HasOne("VisitorSystem.Entities.Concrete.Department", "Department")
                        .WithMany("Visitors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisitorSystem.Entities.Concrete.User", null)
                        .WithMany("Visitors")
                        .HasForeignKey("UserId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.Department", b =>
                {
                    b.Navigation("Visitors");
                });

            modelBuilder.Entity("VisitorSystem.Entities.Concrete.User", b =>
                {
                    b.Navigation("Visitors");
                });
#pragma warning restore 612, 618
        }
    }
}
