using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Onion.Domain.Models;
using Onion.Service.Interfaces;
using Onion.Service.Services;
using Onion.Service.ViewModels;

namespace Onion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentViewModel studentViewModel)
        {
           await _studentService.Create(studentViewModel);
 
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetAll()
        {
          var result =  await _studentService.GetStudents();

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] StudentViewModel studentViewModel)
        {
             await _studentService.Update(id, studentViewModel);

            return Ok();
        }


    }
}