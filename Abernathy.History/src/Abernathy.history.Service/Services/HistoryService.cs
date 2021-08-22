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
        private readonly IMapper _mapper;
        public HistoryService(IHistoryRepository historyRepository,
                                IMapper mapper)
        {
            _historyRepository = historyRepository;
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

            var result =  await _historyRepository.GetAsync(Id);

            if (result == null)
            {
                throw new ArgumentException();
            }

            return result.FirstOrDefault();
        }

        public async Task<Note> CreateNote(NoteDTO model)
        {
            if (model == null)
            {
                throw new ArgumentException();
            }
            var entity = _mapper.Map<Note>(model);

            // check if patient exists

            await _historyRepository.CreateAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<Note>> GetNotesByPatientAsync(int patientId)
        {
            if (patientId <= 0)
            {
                throw new ArgumentException(nameof(patientId));
            }

            var result = await _historyRepository.GetAsync(patientId);

            return result;
        }

        public Task<Note> UpdateNote(NoteDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<Note> DeleteNote(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
