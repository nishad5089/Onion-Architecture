using System.Collections.Generic;
using Onion.Domain.Models;
using Onion.Repository.Interfaces;

namespace Onion.Repository.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(IApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Student> GetStudentVaiDept()
        {
            throw new System.NotImplementedException();
        }

    }
}