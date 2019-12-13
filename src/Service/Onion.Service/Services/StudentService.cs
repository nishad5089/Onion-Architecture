using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onion.Domain.Models;
using Onion.Repository.Interfaces;
using Onion.Repository.Repositories;
using Onion.Service.Interfaces;
using Onion.Service.ViewModels;

namespace Onion.Service.Services {
    public class StudentService : IStudentService {
        private readonly IStudentRepository _studentRepository;

        public StudentService (IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }
        public async Task Create (StudentViewModel studentViewModel) {
            var student = new Student ();
            student.SetName (studentViewModel.Name);
            await _studentRepository.Insert (student);
        }

        public async Task<IEnumerable<StudentViewModel>> GetStudents () {
            // IEnumerable<StudentViewModel> studentViewModels = (IEnumerable<StudentViewModel>) _studentRepository.GetAll ();

            var students = await _studentRepository.GetAll ();
            var studentVm = new List<StudentViewModel> ();
            foreach (var student in students) {
                studentVm.Add (new StudentViewModel {
                    Name = student.Name
                });
            }
            return studentVm;
        }

        public async Task Update (Guid id, StudentViewModel studentViewModel) {
            var student = await _studentRepository.Get (id);
            student.SetName (studentViewModel.Name);
            _studentRepository.Update (student);
            await _studentRepository.Save ();
        }
    }
}