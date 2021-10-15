using Abernathy.history.Service.Models.Entities;
using Abernathy.history.Service.Repository.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private const string CollectionName = "Notes";
        private readonly IMongoCollection<Note> dbCollection;
        private readonly FilterDefinitionBuilder<Note> filterBuilder = Builders<Note>.Filter;

        public HistoryRepository(IMongoDatabase database)
        {
            dbCollection = database.GetCollection<Note>(CollectionName);
        }

        public async Task<IReadOnlyCollection<Note>> GetAllAsync()
        {
            var entites = await dbCollection.Find(filterBuilder.Empty).ToListAsync();
            return entites;
        }

        public async Task<IEnumerable<Note>> GetAsync(int Id)
        {
            FilterDefinition<Note> filter = filterBuilder.Eq(entity => entity.Id, Id);
            var entites = await dbCollection.FindAsync(filter);
            return entites.ToEnumerable();
        }

        public async Task CreateAsync(Note model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await dbCollection.InsertOneAsync(model);
        }

        public async Task UpdateAsync(Note model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            FilterDefinition<Note> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, model.Id);
            await dbCollection.ReplaceOneAsync(filter, model);
        }

        public async Task RemoveAsync(int Id)
        {
            FilterDefinition<Note> filter = filterBuilder.Eq(entity => entity.Id, Id);
            await dbCollection.DeleteOneAsync(filter);
        }

        public async Task<Note> GetById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException(nameof(Id));
            }

            FilterDefinition<Note> filter = filterBuilder.Eq(entity => entity.Id, Id);
            var result = await dbCollection.Find(filter).SingleAsync();

            return result;
        }

        public async Task<IEnumerable<Note>> GetPatientById(int patientId)
        {
            if (patientId <= 0)
            {
                throw new ArgumentException(nameof(patientId));
            }

            FilterDefinition<Note> filter = filterBuilder.Eq(entity => entity.PatientId, patientId);
            var result = await dbCollection.Find(filter).ToListAsync();

            return result;
        }
    }
}
