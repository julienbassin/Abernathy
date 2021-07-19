using System.Threading.Tasks;

namespace Abernathy.Demographics.Service.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IPatientRepository PatientRepository { get; }
        IAddressRepository AddressRepository { get; }
        IPhoneNumberRepository PhoneNumberRepository { get; }
        Task CommitAsync();
        Task RollBackAsync();
    }
}