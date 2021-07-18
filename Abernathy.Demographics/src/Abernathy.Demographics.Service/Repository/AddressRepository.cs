using Abernathy.Demographics.Service.Data;
using Abernathy.Demographics.Service.Models.Entities;
using Abernathy.Demographics.Service.Repository.Interfaces;

namespace Abernathy.Demographics.Service.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(DemographicsContext context) : base(context)
        {
        }
    }
}