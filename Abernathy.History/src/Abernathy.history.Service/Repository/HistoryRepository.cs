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

        public HistoryRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Notes");
            dbCollection = database.GetCollection<Note>(CollectionName);
        }

        public async Task<IReadOnlyCollection<Note>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Note> GetAsync(int Id)
        {
            FilterDefinition<Note> filter = filterBuilder.Eq(entity => entity.Id, Id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Note entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await dbCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Note entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<Note> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await dbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsync(int Id)
        {
            FilterDefinition<Note> filter = filterBuilder.Eq(entity => entity.Id, Id);
            await dbCollection.DeleteOneAsync(filter);
        }
    }
}
