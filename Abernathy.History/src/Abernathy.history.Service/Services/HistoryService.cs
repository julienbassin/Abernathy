using Abernathy.history.Service.Models.Entities;
using Abernathy.history.Service.Repository.Interfaces;
using Abernathy.history.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;
        public HistoryService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<IEnumerable<Note>> GetAll()
        {
            return await _historyRepository.GetAllAsync();
        }



    }
}
