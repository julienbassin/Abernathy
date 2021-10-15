using Abernathy.history.Service.Models.DTOs;
using Abernathy.history.Service.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<IEnumerable<Note>> GetAllNotes();
        Task<Note> GetNoteById(int Id);
        Task<IEnumerable<Note>> GetNotesByPatientIdAsync(int patientId);
        Task<Note> CreateNote(NoteDTO model);
        Task<Note> UpdateNote(NoteDTO model);
        void DeleteNote(int Id);
    }
}
