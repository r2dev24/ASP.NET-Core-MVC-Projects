﻿// <auto-generated />
using System;
using Employee.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employee.Migrations
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

            modelBuilder.Entity("Employee.Models.EmployeeAddressModel", b =>
                {
                    b.Property<int>("Address_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Address_ID"));

                    b.Property<string>("Address_City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Employee_ID")
                        .HasColumnType("int");

                    b.HasKey("Address_ID");

                    b.HasIndex("Employee_ID")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Employee.Models.EmployeeCareerModel", b =>
                {
                    b.Property<int>("Career_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Career_ID"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Employee_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Career_ID");

                    b.HasIndex("Employee_ID")
                        .IsUnique();

                    b.ToTable("Career");
                });

            modelBuilder.Entity("Employee.Models.EmployeeEducationModel", b =>
                {
                    b.Property<int>("Education_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Education_ID"));

                    b.Property<string>("Education_Major")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education_School")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Employee_ID")
                        .HasColumnType("int");

                    b.HasKey("Education_ID");

                    b.HasIndex("Employee_ID")
                        .IsUnique();

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("Employee.Models.EmployeeModel", b =>
                {
                    b.Property<int>("Employee_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Employee_ID"));

                    b.Property<DateTime>("Employee_BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Employee_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Employee_ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Employee.Models.EmployeeAddressModel", b =>
                {
                    b.HasOne("Employee.Models.EmployeeModel", "EmployeeModel")
                        .WithOne("AddressModel")
                        .HasForeignKey("Employee.Models.EmployeeAddressModel", "Employee_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeModel");
                });

            modelBuilder.Entity("Employee.Models.EmployeeCareerModel", b =>
                {
                    b.HasOne("Employee.Models.EmployeeModel", "EmployeeModel")
                        .WithOne("CareerModell")
                        .HasForeignKey("Employee.Models.EmployeeCareerModel", "Employee_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeModel");
                });

            modelBuilder.Entity("Employee.Models.EmployeeEducationModel", b =>
                {
                    b.HasOne("Employee.Models.EmployeeModel", "EmployeeModel")
                        .WithOne("EducationModel")
                        .HasForeignKey("Employee.Models.EmployeeEducationModel", "Employee_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeModel");
                });

            modelBuilder.Entity("Employee.Models.EmployeeModel", b =>
                {
                    b.Navigation("AddressModel")
                        .IsRequired();

                    b.Navigation("CareerModell")
                        .IsRequired();

                    b.Navigation("EducationModel")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
