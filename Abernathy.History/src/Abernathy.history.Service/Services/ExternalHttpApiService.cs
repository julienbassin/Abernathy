using Abernathy.history.Service.Services.Interfaces;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Services
{
    public class ExternalHttpApiService : IHttpExternalApiService
    {
        private readonly HttpClient _httpClient;
        public ExternalHttpApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> GetPatientById(int Id)
        {
            var isPatientExists = false;

            try
            {
                var response = await _httpClient.GetAsync($"/api/patient/{Id}");

                isPatientExists = response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }           

            return isPatientExists;
        }
    }
}
