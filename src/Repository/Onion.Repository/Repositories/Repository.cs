using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onion.Repository.Interfaces;

namespace Onion.Repository.Repositories {
    public class Repository<T> : IRepository<T> where T : class {

        private readonly DbSet<T> _entities;
        private readonly IApplicationDbContext _context;
        public Repository (IApplicationDbContext context) {
            _context = context;
            _entities = _context.Set<T> ();
        }
        public async Task DeleteAsync (T entity) {
            T existing = _entities.Find (entity);
            if (existing != null) {
                _entities.Remove (existing);

                await _context.SaveChangesAsync ();
            }
        }

        public async Task<T> Get (Guid id) {
            return await _entities.FindAsync (id);
        }

        public async Task<IEnumerable<T>> GetAll () {
            return await _entities.ToListAsync<T> ();
        }

        public IEnumerable<T> GetAllByPredicate (Expression<Func<T, bool>> expression) {
            throw new System.NotImplementedException ();
        }

        public async Task Insert (T entity) {
            await _entities.AddAsync (entity);
            await _context.SaveChangesAsync ();
        }

        public void Update (T entity) {
            _entities.Attach (entity);
            _context.Entry<T> (entity).State = EntityState.Modified;
        }

        public async Task Save () {
            await _context.SaveChangesAsync ();
        }

    }
}