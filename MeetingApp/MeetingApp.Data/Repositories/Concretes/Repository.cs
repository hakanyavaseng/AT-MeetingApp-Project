﻿using MeetingApp.Core.Entities;
using MeetingApp.Data.Contexts;
using MeetingApp.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MeetingApp.Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly MeetingAppDbContext _context;
        private DbSet<T> Table { get => _context.Set<T>(); }

        public Repository(MeetingAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity) => await Table.AddAsync(entity);
        public void Update(T entity) => Table.Update(entity);
        public async Task DeleteAsync(T entity) => await Task.Run(() => Table.Remove(entity));
        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> predicate = null, bool trackChanges = false)
        {
            IQueryable<T> query = Table;

            if(predicate is not null)
                query.Where(predicate);
            if (!trackChanges)
                query.AsNoTracking();
            return query;  
        }
        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate = null, bool trackChanges = false)
        {
            IQueryable<T> query = Table;
            if(predicate is not null)
                query = query.Where(predicate);
            if (!trackChanges)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }
        public async Task<T?> GetByIdAsync(Guid id, bool trackChanges = false)
        {
            IQueryable<T> query = Table;
            if (!trackChanges)
                query.AsNoTracking();
            return await query.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }
        public async Task AddRangeAsync(IEnumerable<T> entities) => await Table.AddRangeAsync(entities);
       
    }
}
