﻿// <auto-generated />
using System;
using Abernathy.Demographics.Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Abernathy.Demographics.Service.Migrations
{
    [DbContext(typeof(DemographicsContext))]
    partial class DemographicsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HouseNumber")
                        .HasMaxLength(6)
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("ZIPCode");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Gender");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Female"
                        });
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 0,
                            DateOfBirth = new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "James",
                            GenderId = 1,
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 2,
                            Age = 0,
                            DateOfBirth = new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jiyeon",
                            GenderId = 2,
                            LastName = "Lee"
                        },
                        new
                        {
                            Id = 3,
                            Age = 0,
                            DateOfBirth = new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Masaaki",
                            GenderId = 1,
                            LastName = "Abe"
                        },
                        new
                        {
                            Id = 4,
                            Age = 0,
                            DateOfBirth = new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Anna",
                            GenderId = 2,
                            LastName = "Svensson"
                        },
                        new
                        {
                            Id = 5,
                            Age = 0,
                            DateOfBirth = new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Nurma",
                            GenderId = 1,
                            LastName = "Haitam"
                        },
                        new
                        {
                            Id = 6,
                            Age = 0,
                            DateOfBirth = new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Lucy",
                            GenderId = 2,
                            LastName = "Johnson"
                        },
                        new
                        {
                            Id = 7,
                            Age = 0,
                            DateOfBirth = new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Brian",
                            GenderId = 1,
                            LastName = "Aleesami"
                        },
                        new
                        {
                            Id = 8,
                            Age = 0,
                            DateOfBirth = new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Elizabeth",
                            GenderId = 2,
                            LastName = "van Lingen"
                        },
                        new
                        {
                            Id = 9,
                            Age = 0,
                            DateOfBirth = new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Okparaebo",
                            GenderId = 2,
                            LastName = "Vivienne"
                        },
                        new
                        {
                            Id = 10,
                            Age = 0,
                            DateOfBirth = new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "King",
                            GenderId = 1,
                            LastName = "Andrew"
                        },
                        new
                        {
                            Id = 11,
                            Age = 0,
                            DateOfBirth = new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Locke",
                            GenderId = 1,
                            LastName = "Brian"
                        },
                        new
                        {
                            Id = 12,
                            Age = 0,
                            DateOfBirth = new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Wang",
                            GenderId = 2,
                            LastName = "Su Lin"
                        });
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.PatientAddress", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("PatientAddress");
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.PatientPhoneNumber", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumberId")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "PhoneNumberId");

                    b.HasIndex("PhoneNumberId");

                    b.ToTable("PatientPhoneNumbers");
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhoneType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.Patient", b =>
                {
                    b.HasOne("Abernathy.Demographics.Service.Models.Entities.Gender", "type")
                        .WithMany("Patients")
                        .HasForeignKey("GenderId")
                        .HasConstraintName("FK_Patient_Gender")
                        .IsRequired();

                    b.Navigation("type");
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.PatientAddress", b =>
                {
                    b.HasOne("Abernathy.Demographics.Service.Models.Entities.Address", "Address")
                        .WithMany("PatientAddresses")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_PatientAddress_Patient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abernathy.Demographics.Service.Models.Entities.Patient", "Patient")
                        .WithMany("PatientAddresses")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK_PatientAddress_Address")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.PatientPhoneNumber", b =>
                {
                    b.HasOne("Abernathy.Demographics.Service.Models.Entities.Patient", "Patient")
                        .WithMany("PatientPhoneNumbers")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK_PatientPhoneNumber_PhoneNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abernathy.Demographics.Service.Models.Entities.PhoneNumber", "PhoneNumber")
                        .WithMany("PatientPhoneNumbers")
                        .HasForeignKey("PhoneNumberId")
                        .HasConstraintName("FK_PatientPhoneNumber_Patient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("PhoneNumber");
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.Address", b =>
                {
                    b.Navigation("PatientAddresses");
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.Gender", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.Patient", b =>
                {
                    b.Navigation("PatientAddresses");

                    b.Navigation("PatientPhoneNumbers");
                });

            modelBuilder.Entity("Abernathy.Demographics.Service.Models.Entities.PhoneNumber", b =>
                {
                    b.Navigation("PatientPhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
