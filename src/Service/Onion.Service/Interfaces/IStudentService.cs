using System.Threading.Tasks;
using System.Collections.Generic;
using Onion.Service.ViewModels;
using System;

namespace Onion.Service.Interfaces
{
    public interface IStudentService
    {
          Task<IEnumerable<StudentViewModel>> GetStudents();
          Task Create(StudentViewModel studentViewModel);

          Task Update(Guid id, StudentViewModel studentViewModel);
    }
}