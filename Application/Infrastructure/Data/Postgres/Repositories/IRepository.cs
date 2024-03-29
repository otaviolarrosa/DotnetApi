﻿using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Infrastructure.Data.Postgres.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        T GetById(Guid id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
