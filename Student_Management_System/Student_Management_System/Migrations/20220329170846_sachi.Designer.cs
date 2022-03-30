﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student_Management_System.DataBaseContext;

namespace Student_Management_System.Migrations
{
    [DbContext(typeof(SmsDbContext))]
    [Migration("20220329170846_sachi")]
    partial class sachi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Student_Management_System.Models.Student", b =>
                {
                    b.Property<int>("studentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("course")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Course");

                    b.Property<int?>("userID")
                        .HasColumnType("int");

                    b.HasKey("studentId");

                    b.HasIndex("userID")
                        .IsUnique()
                        .HasFilter("[userID] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Student_Management_System.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Email");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("Name");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("Password");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Role");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Student_Management_System.Models.Student", b =>
                {
                    b.HasOne("Student_Management_System.Models.User", "user")
                        .WithOne("student")
                        .HasForeignKey("Student_Management_System.Models.Student", "userID");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Student_Management_System.Models.User", b =>
                {
                    b.Navigation("student");
                });
#pragma warning restore 612, 618
        }
    }
}
