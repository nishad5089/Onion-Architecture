using System.Collections.Generic;
using Onion.Domain.Models;

namespace Onion.Repository.Interfaces
{
    public interface IStudentRepository : IRepository<Student> 
    {
         IEnumerable<Student> GetStudentVaiDept();
    }
}