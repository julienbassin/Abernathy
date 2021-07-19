using Abernathy.Demographics.Service.Data;
using Abernathy.Demographics.Service.Models.Entities;
using Abernathy.Demographics.Service.Repository.Interfaces;

namespace Abernathy.Demographics.Service.Repository
{
    public class PhoneNumberRepository : Repository<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(DemographicsContext context) : base(context)
        {
        }
    }
}