using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Onion.Repository.Interfaces {
    public interface IRepository<T> where T : class {
        Task<T> Get (Guid id);
        Task<IEnumerable<T>> GetAll ();
        IEnumerable<T> GetAllByPredicate (Expression<Func<T, bool>> expression);
        Task Insert (T entity);
        void Update (T entity);
        Task Save();
        Task DeleteAsync (T entity);
    }
}