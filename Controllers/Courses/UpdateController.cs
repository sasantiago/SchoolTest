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

    public class UpdateController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;

        public UpdateController(ICoursesRepository coursesRepositor)
        {

            _coursesRepository = coursesRepositor;
        }

        [HttpPut]
        [Route("api/CoursesUpdate/{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course course)
        {

            if (!ModelState.IsValid)
                return BadRequest("Datos del medico vacios !");

            try
            {
                var resulteacher = _coursesRepository.GetById(id);
                if (resulteacher == null)
                {
                    return NotFound($"not found this Teacher with this id {id}");
                }
                _coursesRepository.Update(course);
                return Ok("Teacher is updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}