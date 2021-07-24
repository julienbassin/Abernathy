namespace Abernathy.Demographics.Service.Repository.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> FindAll();
    }
}