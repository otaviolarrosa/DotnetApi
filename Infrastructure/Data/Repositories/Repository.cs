using Application.Infrastructure.Data.Repositories;
using Domain.Entities;
using Infrastructure.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories
{

    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly DataContext _context;
        public Repository(IServiceScopeFactory factory)
        {
            _context = factory.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }
        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsQueryable();
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
        public T GetById(Guid id)
        {
            return _context.Set<T>().Where(x => x.Id == id).FirstOrDefault();
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
    }
}
