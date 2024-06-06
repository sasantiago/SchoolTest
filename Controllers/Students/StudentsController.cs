using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Services;
using School.Services.Students;

namespace School.Controllers.Students
{

    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsController(IStudentsRepository studentsRepository)
        {

            _studentsRepository = studentsRepository;
        }

        [HttpGet]
        [Route("api/Students/")]
        public IActionResult GetAllTeachers()
        {
            try
            {
                var students = _studentsRepository.GetAll();
                return Ok(students);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/Students/{id}")]
        public IActionResult GetTeacherById(int id)
        {

            try
            {
                var result = _studentsRepository.GetById(id);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("api/Students/GetAllByBirthDay/{BirthDay}")]
        public IActionResult GetAllByBirthDays (string Birthday){
            try
            {
                var result = _studentsRepository.GetAllByBirthDay(Birthday);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}