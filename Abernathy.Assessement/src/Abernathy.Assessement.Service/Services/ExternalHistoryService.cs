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
    public class ExternalHistoryService : IExternalHistoryService
    {
        private readonly HttpClient _httpClient;
        public ExternalHistoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<NoteModel>> GetNotesPatientById(int Id)
        {
            IEnumerable<NoteModel> notes = null;

            try
            {
                var response = await _httpClient.GetAsync($"/api/History/Patient/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    notes = JsonParseContent.DeserializeJsonFromStream<IEnumerable<NoteModel>>(stream);
                }
                else
                {
                    notes = new List<NoteModel>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return notes;
        }
    }
}
