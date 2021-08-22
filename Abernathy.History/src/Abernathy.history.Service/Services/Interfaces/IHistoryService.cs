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
        Task<IEnumerable<Note>> GetNotesByPatientAsync(int patientId);
        Task<Note> GetNoteById(int Id);
        Task<Note> CreateNote(NoteDTO model);
        Task<Note> UpdateNote(NoteDTO model);
        Task<Note> DeleteNote(int Id);
    }
}
