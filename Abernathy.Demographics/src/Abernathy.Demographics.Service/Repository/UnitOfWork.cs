using System.Threading.Tasks;
using Abernathy.Demographics.Service.Data;
using Abernathy.Demographics.Service.Repository.Interfaces;

namespace Abernathy.Demographics.Service.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DemographicsContext _context;
        public IPatientRepository _patientRepository;
        public IAddressRepository _addressRepository;
        public IPhoneNumberRepository _phoneNumberRepository;
        public UnitOfWork(DemographicsContext context)
        {
            _context = context;
        }

        public IPatientRepository PatientRepository =>
            _patientRepository ??= new PatientRepository(_context);

        public IAddressRepository AddressRepository =>
            _addressRepository ??= new AddressRepository(_context);

        public IPhoneNumberRepository PhoneNumberRepository =>
            _phoneNumberRepository ??= new PhoneNumberRepository(_context);

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