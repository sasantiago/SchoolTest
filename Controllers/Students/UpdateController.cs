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

    public class UpdateController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public UpdateController(IStudentsRepository studentsRepository)
        {

            _studentsRepository = studentsRepository;
        }
        [HttpPut]
        [Route("api/StudentsUpdate/{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {

            if (!ModelState.IsValid)
                return BadRequest("Data empty !");

            try
            {
                var resulteacher = _studentsRepository.GetById(id);
                if (resulteacher == null)
                {
                    return NotFound($"not found this Teacher with this id {id}");
                }
                _studentsRepository.Update(student);
                return Ok("Student is updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}