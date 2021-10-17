using System.Threading.Tasks;
using Abernathy.Demographics.Service.Data;
using Abernathy.Demographics.Service.Models.Entities;
using Abernathy.Demographics.Service.Repository.Interfaces;

namespace Abernathy.Demographics.Service.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DemographicsContext _context;
        public IRepository<Patient> _patientRepository;
        public IRepository<Address> _addressRepository;
        public IRepository<PhoneNumber> _phoneNumberRepository;
        public UnitOfWork(DemographicsContext context)
        {
            _context = context;
        }

        public IRepository<Patient> PatientRepository =>
            _patientRepository ??= new Repository<Patient>(_context);

        public IRepository<Address> AddressRepository =>
            _addressRepository ??= new Repository<Address>(_context);

        public IRepository<PhoneNumber> PhoneNumberRepository =>
            _phoneNumberRepository ??= new Repository<PhoneNumber>(_context);

        public void Commit()
        {
            _context.SaveChanges();
            _context.Dispose();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RollBackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}