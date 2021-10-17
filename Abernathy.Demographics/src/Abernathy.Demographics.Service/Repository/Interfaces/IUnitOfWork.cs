using System.Threading.Tasks;
using Abernathy.Demographics.Service.Models.Entities;

namespace Abernathy.Demographics.Service.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Patient> PatientRepository { get; }
        IRepository<Address> AddressRepository { get; }
        IRepository<PhoneNumber> PhoneNumberRepository { get; }

        void Commit();
        Task CommitAsync();
        Task RollBackAsync();
    }
}