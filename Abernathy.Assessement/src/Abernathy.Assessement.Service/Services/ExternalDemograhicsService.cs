using Abernathy.Assessement.Service.Models.Entities;
using Abernathy.Assessement.Service.Services.Interfaces;
using Abernathy.Assessement.Service.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

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
            try
            {
                var httpResponse = _httpClient.GetAsync($"/api/patient/{Id}");
                var response = httpResponse.Result;
                var jsonString = response.Content.ReadAsStringAsync().Result;
                dynamic x = JsonConvert.DeserializeObject(jsonString);

                PatientModel currentPatient = new PatientModel
                {
                    Id = (int)x.result.id,
                    FirstName = (string)x.result.firstName,
                    LastName = (string)x.result.lastName,
                    Age = (int)x.result.age,
                    DateOfBirth = (DateTime)x.result.dateOfBirth,
                    GenderId = (int)x.result.genderId
                };

                return currentPatient;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            }
        }
    }
}
