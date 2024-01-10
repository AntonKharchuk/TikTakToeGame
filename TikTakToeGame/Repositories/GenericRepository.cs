
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using TikTakToeGame.Entities;
using TikTakToeGame.Exceptions;

namespace TikTakToeGame.Repositories
{
    
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        private DbSet<T> _table;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(string includes = "")
        {
            var query = _table.AsQueryable();
            query = IncludeFields(includes, query);
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, string includes = "")
        {
            var query = _table.AsQueryable();

            query = IncludeFields(includes, query);

            return await query.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddAsync(T entity)
        {
            ThrowIfNull(entity);
            await _table.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity, int id)
        {
            ThrowIfNull(entity);
            if (entity.Id != id)
            {
                throw new ArgumentException(nameof(entity), "entity.Id and id missmatch");
            }
            var tableEntity = await GetByIdAsync(id);
            ThrowIfNull(tableEntity);
            _context.Entry(tableEntity).CurrentValues.SetValues(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var tableEntity = await GetByIdAsync(id);
            ThrowIfNull(tableEntity);
            _table.Remove(tableEntity);
        }
        private static void ThrowIfNull(T? entity)
        {
            if (entity is null)
            {
                throw new EntityNotFoundException("Entity with the specified ID not found.");
            }
        }
        private static IQueryable<T> IncludeFields(string includes, IQueryable<T> query)
        {
            if (!string.IsNullOrEmpty(includes))
            {
                foreach (var include in includes.Split(","))
                {
                    query = query.Include(include);
                }
            }

            return query;
        }
    }
}
