using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Services.Interfaces
{
    public interface IHttpExternalApiService
    {
        Task<bool> PatientExists(int Id);
    }
}
