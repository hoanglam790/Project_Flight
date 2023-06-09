﻿// <auto-generated />
using System;
using FlightDocs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightDocs.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230619125428_FlightDocs")]
    partial class FlightDocs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightDocs.Models.Document", b =>
                {
                    b.Property<int>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentTypeTypeID")
                        .HasColumnType("int");

                    b.Property<string>("FlightID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentID");

                    b.HasIndex("DocumentTypeTypeID");

                    b.HasIndex("FlightID");

                    b.HasIndex("UserID");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("FlightDocs.Models.DocumentType", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TyleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeID");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("FlightDocs.Models.Flight", b =>
                {
                    b.Property<string>("FlightID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightTo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightDocs.Models.GroupPermission", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DocumentID")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PermissionID")
                        .HasColumnType("int");

                    b.HasKey("GroupID");

                    b.HasIndex("DocumentID");

                    b.HasIndex("PermissionID");

                    b.ToTable("GroupPermissions");
                });

            modelBuilder.Entity("FlightDocs.Models.Permission", b =>
                {
                    b.Property<int>("PermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionID"));

                    b.Property<string>("PermissionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermissionID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("FlightDocs.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FlightDocs.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupID")
                        .HasColumnType("int");

                    b.Property<int?>("GroupPermissionGroupID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHashing")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResetPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TokenExpire")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerifyToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VeryfiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserID");

                    b.HasIndex("GroupPermissionGroupID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlightDocs.Models.Document", b =>
                {
                    b.HasOne("FlightDocs.Models.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeTypeID");

                    b.HasOne("FlightDocs.Models.Flight", "Flight")
                        .WithMany("Documents")
                        .HasForeignKey("FlightID");

                    b.HasOne("FlightDocs.Models.User", "User")
                        .WithMany("Documents")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("Flight");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightDocs.Models.GroupPermission", b =>
                {
                    b.HasOne("FlightDocs.Models.Document", "Document")
                        .WithMany("GroupPermissions")
                        .HasForeignKey("DocumentID");

                    b.HasOne("FlightDocs.Models.Permission", "Permission")
                        .WithMany("GroupPermissions")
                        .HasForeignKey("PermissionID");

                    b.Navigation("Document");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("FlightDocs.Models.User", b =>
                {
                    b.HasOne("FlightDocs.Models.GroupPermission", "GroupPermission")
                        .WithMany("Users")
                        .HasForeignKey("GroupPermissionGroupID");

                    b.HasOne("FlightDocs.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID");

                    b.Navigation("GroupPermission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FlightDocs.Models.Document", b =>
                {
                    b.Navigation("GroupPermissions");
                });

            modelBuilder.Entity("FlightDocs.Models.DocumentType", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("FlightDocs.Models.Flight", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("FlightDocs.Models.GroupPermission", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FlightDocs.Models.Permission", b =>
                {
                    b.Navigation("GroupPermissions");
                });

            modelBuilder.Entity("FlightDocs.Models.User", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
