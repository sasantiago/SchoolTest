using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services;
using School.Services.Courses;

namespace School.Controllers.Courses
{
    
    public class CreateController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;

        public CreateController(ICoursesRepository coursesRepositor){

            _coursesRepository = coursesRepositor;
        }

       
        [HttpPost]
        [Route("api/CourseCreate/")]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            try
            {
                _coursesRepository.Create(course);
                return Ok("Course has been created");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}