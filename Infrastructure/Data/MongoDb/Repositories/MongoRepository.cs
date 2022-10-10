using System.Linq.Expressions;
using Application.Infrastructure.Data.MongoDb.Repositories;
using Domain.Entities;
using Infrastructure.Data.MongoDb.Settings;
using MongoDB.Driver;

namespace Infrastructure.Data.MongoDb.Repositories;

public class MongoRepository<TDocument> : IMongoRepository<TDocument>
    where TDocument : EntityBase
{
    private readonly IMongoCollection<TDocument> _collection;

    public MongoRepository(IMongoDbSettings settings)
    {
        var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<TDocument>(settings.UserCollection);
    }

    public virtual IQueryable<TDocument> AsQueryable() => _collection.AsQueryable();

    public IEnumerable<TDocument> FilterBy(
        Expression<Func<TDocument, bool>> filterExpression) =>
        _collection.Find(filterExpression).ToEnumerable();

    public IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TDocument, bool>> filterExpression,
        Expression<Func<TDocument, TProjected>> projectionExpression) =>
        _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();

    public TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression) => _collection.Find(filterExpression).FirstOrDefault();

    public async Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression) => await _collection.Find(filterExpression).FirstOrDefaultAsync();

    public TDocument FindById(Guid id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
        return _collection.Find(filter).SingleOrDefault();
    }

    public async Task<TDocument> FindByIdAsync(Guid id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public void InsertOne(TDocument document) => _collection.InsertOne(document);

    public async Task InsertOneAsync(TDocument document) => await _collection.InsertOneAsync(document);

    public void InsertMany(ICollection<TDocument> documents) => _collection.InsertMany(documents);

    public async Task InsertManyAsync(ICollection<TDocument> documents) => await _collection.InsertManyAsync(documents);

    public void ReplaceOne(TDocument document)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
        _collection.FindOneAndReplace(filter, document);
    }

    public async Task ReplaceOneAsync(TDocument document)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
        await _collection.FindOneAndReplaceAsync(filter, document);
    }

    public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression) => _collection.FindOneAndDelete(filterExpression);

    public async Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression) => await _collection.FindOneAndDeleteAsync(filterExpression);

    public void DeleteById(Guid id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
        _collection.FindOneAndDelete(filter);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
        await _collection.FindOneAndDeleteAsync(filter);
    }

    public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression) => _collection.DeleteMany(filterExpression);

    public async Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression) => await _collection.DeleteManyAsync(filterExpression);
}