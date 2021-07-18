using System.Collections.Generic;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Data;
using Abernathy.Demographics.Service.Models.Entities;
using Abernathy.Demographics.Service.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Abernathy.Demographics.Service.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DemographicsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Patient>> FindAll()
        {
            return await base.Find(p => true)
                    .Include(p => p.PatientAddresses).ThenInclude(pa => pa.Address)
                    .Include(p => p.PatientPhoneNumbers).ThenInclude(pp => pp.PhoneNumber)
                    .Include(p => p.Type).ToListAsync();
        }
    }
}