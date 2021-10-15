using Abernathy.Assessement.Service.Models.Entities;
using Abernathy.Assessement.Service.Services.Interfaces;
using Abernathy.Assessement.Service.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Abernathy.Assessement.Service.Services
{
    public class ExternalDemograhicsService : IExternalDemographicsService
    {
        private readonly HttpClient _httpClient;

        public ExternalDemograhicsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PatientModel> GetPatientById(int Id)
        {
            PatientModel currentPatient = null;

            try
            {
                var response = await _httpClient.GetAsync($"/api/Patient/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    currentPatient =  JsonParseContent.DeserializeJsonFromStream<PatientModel>(stream);
                }
                else
                {
                    currentPatient = new PatientModel();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return currentPatient;
        }
    }
}
