using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services;
using School.Services.Students;

namespace School.Controllers.Students
{

    public class CreateController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public CreateController(IStudentsRepository studentsRepository)
        {

            _studentsRepository = studentsRepository;
        }

        [HttpPost]
        [Route("api/CreateStudents/")]
        
        public IActionResult CreateTeachers([FromBody] Student student)
        {
            try
            {
                _studentsRepository.Create(student);
                return Ok("Student has been created");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

      
    }
}