using Abernathy.history.Service.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Repository.Interfaces
{
    public interface IHistoryRepository
    {
        Task CreateAsync(Note entity);
        Task<IReadOnlyCollection<Note>> GetAllAsync();
        Task<Note> GetAsync(int Id);
        Task RemoveAsync(int Id);
        Task UpdateAsync(Note entity);
    }
}