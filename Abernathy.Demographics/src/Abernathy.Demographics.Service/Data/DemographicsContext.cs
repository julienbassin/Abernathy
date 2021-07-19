using Abernathy.Demographics.Service.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abernathy.Demographics.Service.Data
{
    public class DemographicsContext : DbContext
    {
        public DemographicsContext() { }

        public DemographicsContext(DbContextOptions<DemographicsContext> options) : base(options) { }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<PatientAddress> PatientAddress { get; set; }
        public DbSet<PatientPhoneNumber> PatientPhoneNumbers { get; set; }
    }

}