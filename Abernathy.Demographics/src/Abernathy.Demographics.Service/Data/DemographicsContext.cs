using System;
using System.Collections.Generic;
using Abernathy.Demographics.Service.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abernathy.Demographics.Service.Data
{
    public class DemographicsContext : DbContext
    {
        public DemographicsContext(DbContextOptions<DemographicsContext> options) : base(options) { }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<PatientAddress> PatientAddress { get; set; }
        public DbSet<PatientPhoneNumber> PatientPhoneNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AbernatyPatientDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AbernathyPatientDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.Property(e => e.PhoneType)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasColumnName("ZIPCode")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.GenderId);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Gender")
                    .IsRequired();
            });

            modelBuilder.Entity<PatientAddress>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.AddressId });

                entity.HasOne<Patient>(d => d.Patient)
                    .WithMany(p => p.PatientAddresses)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PatientAddress_Address");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.PatientAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PatientAddress_Patient");
            });

            modelBuilder.Entity<PatientPhoneNumber>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.PhoneNumberId });

                entity.HasOne(a => a.Patient)
                    .WithMany(b => b.PatientPhoneNumbers)
                    .HasForeignKey(a => a.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PatientPhoneNumber_PhoneNumber");

                entity.HasOne(a => a.PhoneNumber)
                    .WithMany(b => b.PatientPhoneNumbers)
                    .HasForeignKey(a => a.PhoneNumberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PatientPhoneNumber_Patient");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Type)
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Gender>()
                .HasData(
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

            modelBuilder.Entity<Patient>()
                .HasData(
                    new Patient
                    {
                        Id = 1,
                        GenderId = 1,
                        LastName = "Smith",
                        FirstName = "James",
                        DateOfBirth = new DateTime(1960, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 2,
                        GenderId = 2,
                        LastName = "Lee",
                        FirstName = "Jiyeon",
                        DateOfBirth = new DateTime(1960, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 3,
                        GenderId = 1,
                        LastName = "Abe",
                        FirstName = "Masaaki",
                        DateOfBirth = new DateTime(2010, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 4,
                        GenderId = 2,
                        LastName = "Svensson",
                        FirstName = "Anna",
                        DateOfBirth = new DateTime(2010, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 5,
                        GenderId = 1,
                        LastName = "Haitam",
                        FirstName = "Nurma",
                        DateOfBirth = new DateTime(1960, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 6,
                        GenderId = 2,
                        LastName = "Johnson",
                        FirstName = "Lucy",
                        DateOfBirth = new DateTime(1960, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 7,
                        GenderId = 1,
                        LastName = "Aleesami",
                        FirstName = "Brian",
                        DateOfBirth = new DateTime(2010, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 8,
                        GenderId = 2,
                        LastName = "van Lingen",
                        FirstName = "Elizabeth",
                        DateOfBirth = new DateTime(2010, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 9,
                        GenderId = 2,
                        FirstName = "Okparaebo",
                        LastName = "Vivienne",
                        DateOfBirth = new DateTime(1960, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 10,
                        GenderId = 1,
                        FirstName = "King",
                        LastName = "Andrew",
                        DateOfBirth = new DateTime(1960, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 11,
                        GenderId = 1,
                        FirstName = "Locke",
                        LastName = "Brian",
                        DateOfBirth = new DateTime(2010, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 12,
                        GenderId = 2,
                        FirstName = "Wang",
                        LastName = "Su Lin",
                        DateOfBirth = new DateTime(2010, 1, 1),
                        PatientAddresses = new List<PatientAddress>(),
                        PatientPhoneNumbers = new List<PatientPhoneNumber>()
                    }
                );
        }
    }

}