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
        //public DbSet<PatientAddress> PatientAddress { get; set; }
        //public DbSet<PatientPhoneNumber> PatientPhoneNumbers { get; set; }

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

                entity.HasOne(d => d.type)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Gender")
                    .IsRequired();
            });

            //modelBuilder.Entity<PatientAddress>(entity =>
            //{
            //    entity.HasKey(e => new { e.PatientId, e.AddressId });

            //    entity.HasOne(d => d.Address)
            //        .WithMany(p => p.PatientAddresses)
            //        .HasForeignKey(d => d.AddressId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_PatientAddress_Address");

            //    entity.HasOne(d => d.Patient)
            //        .WithMany(p => p.PatientAddresses)
            //        .HasForeignKey(d => d.PatientId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_PatientAddress_Patient");
            //});

            //modelBuilder.Entity<PatientPhoneNumber>(entity =>
            //{
            //    entity.HasKey(e => new { e.PatientId, e.PhoneNumberId });

            //    entity.HasOne(a => a.PhoneNumber)
            //        .WithMany(b => b.PatientPhoneNumbers)
            //        .HasForeignKey(a => a.PhoneNumberId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_PatientPhoneNumber_PhoneNumber");

            //    entity.HasOne(a => a.Patient)
            //        .WithMany(b => b.PatientPhoneNumbers)
            //        .HasForeignKey(a => a.PatientId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_PatientPhoneNumber_Patient");
            //});

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
                        LastName = "Ferguson",
                        FirstName = "Lucas",
                        Age = 53,
                        DateOfBirth = new DateTime(1968, 6, 22),
                        Addresses = new List<Address>(),
                        PhoneNumbers = new List<PhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 2,
                        GenderId = 2,
                        LastName = "Rees",
                        FirstName = "Pippa",
                        Age = 69,
                        DateOfBirth = new DateTime(1952, 9, 27),
                        Addresses = new List<Address>(),
                        PhoneNumbers = new List<PhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 3,
                        GenderId = 1,
                        LastName = "Arnold",
                        FirstName = "Edward",
                        Age = 69,
                        DateOfBirth = new DateTime(1952, 11, 11),
                        Addresses = new List<Address>(),
                        PhoneNumbers = new List<PhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 4,
                        GenderId = 1,
                        LastName = "Sharp",
                        FirstName = "Anthony",
                        Age = 75,
                        DateOfBirth = new DateTime(1946, 11, 26),
                        Addresses = new List<Address>(),
                        PhoneNumbers = new List<PhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 5,
                        GenderId = 2,
                        LastName = "Ince",
                        FirstName = "Wendy",
                        Age = 61,
                        DateOfBirth = new DateTime(1958, 6, 29),
                        Addresses = new List<Address>(),
                        PhoneNumbers = new List<PhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 6,
                        GenderId = 2,
                        LastName = "Ross",
                        FirstName = "Tracey",
                        Age = 72,
                        DateOfBirth = new DateTime(1949, 12, 7),
                        Addresses = new List<Address>(),
                        PhoneNumbers = new List<PhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 7,
                        GenderId = 2,
                        LastName = "Wilson",
                        FirstName = "Claire",
                        Age = 55,
                        DateOfBirth = new DateTime(1966, 12, 31),
                        Addresses = new List<Address>(),
                        PhoneNumbers = new List<PhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 8,
                        GenderId = 1,
                        LastName = "Buckland",
                        FirstName = "Max",
                        Age = 75,
                        DateOfBirth = new DateTime(1945, 6, 24),
                        Addresses = new List<Address>(),
                        PhoneNumbers = new List<PhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 9,
                        GenderId = 2,
                        FirstName = "Clark",
                        LastName = "Natalie",
                        Age = 57,
                        DateOfBirth = new DateTime(1964, 6, 18),
                        Addresses = new List<Address>(),
                        PhoneNumbers = new List<PhoneNumber>()
                    },
                    new Patient
                    {
                        Id = 10,
                        GenderId = 1,
                        FirstName = "Bailey",
                        LastName = "Piers",
                        Age = 61,
                        DateOfBirth = new DateTime(1959, 6, 28),
                        Addresses = new List<Address>(),
                        PhoneNumbers = new List<PhoneNumber>()
                    }
                ) ;
        }
    }

}