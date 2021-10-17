using Abernathy.history.Service.Models.DTOs;
using Abernathy.history.Service.Models.Entities;
using Abernathy.history.Service.Repository.Interfaces;
using Abernathy.history.Service.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;
        private readonly IHttpExternalApiService _httpExternalApiService;
        private readonly IMapper _mapper;
        public HistoryService(IHistoryRepository historyRepository,
                                IHttpExternalApiService httpExternalApiService,
                                IMapper mapper)
        {
            _historyRepository = historyRepository;
            _httpExternalApiService = httpExternalApiService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            return await _historyRepository.GetAllAsync();
        }

        public async Task<Note> GetNoteById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException(); 
            }

            var result =  await _historyRepository.GetById(Id);

            return result;
        }

        public async Task<Note> CreateNote(NoteDTO model)
        {
            if (model == null)
            {
                throw new ArgumentException();
            }
            var entity = _mapper.Map<Note>(model);

            // check if patient exists

            try
            {
                await _httpExternalApiService.PatientExists(model.PatientId);
                await _historyRepository.CreateAsync(entity);
            }
            catch (Exception)
            {
                throw new ArgumentNullException(nameof(model));
            }          

            return entity;
        }

        public async Task<IEnumerable<Note>> GetNotesByPatientIdAsync(int patientId)
        {
            var result = await _historyRepository.GetPatientById(patientId);

            return result;
        }

        public async Task<Note> UpdateNote(NoteDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = _historyRepository.GetById(model.Id);

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var updatedEntity = _mapper.Map<Note>(model);
            await _historyRepository.UpdateAsync(updatedEntity);
            return updatedEntity;

        }

        public void DeleteNote(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException(nameof(Id));
            }
             _historyRepository.RemoveAsync(Id);
        }
    }
}
