﻿// <auto-generated />
using System;
using ERP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ERP.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ERP.Models.Account", b =>
                {
                    b.Property<int>("Account_Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Account_Number"));

                    b.Property<string>("Account_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Account_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Account_Number");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ERP.Models.Employee", b =>
                {
                    b.Property<int>("Employee_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Employee_ID"));

                    b.Property<DateTime>("Employee_DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Employee_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Englisth_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Employee_JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Employee_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Employee_ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ERP.Models.EmployeeAddress", b =>
                {
                    b.Property<int>("Address_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Address_ID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Employee_ID")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Address_ID");

                    b.HasIndex("Employee_ID");

                    b.ToTable("EmployeeAddresses");
                });

            modelBuilder.Entity("ERP.Models.EmployeeEducation", b =>
                {
                    b.Property<int>("EmpEdu_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpEdu_ID"));

                    b.Property<string>("EducationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Employee_ID")
                        .HasColumnType("int");

                    b.Property<string>("School_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpEdu_ID");

                    b.HasIndex("Employee_ID");

                    b.ToTable("EmployeeEducation");
                });

            modelBuilder.Entity("ERP.Models.EmployeeAddress", b =>
                {
                    b.HasOne("ERP.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("Employee_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ERP.Models.EmployeeEducation", b =>
                {
                    b.HasOne("ERP.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("Employee_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
