using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services;
using School.Services.Teachers;

namespace School.Controllers.Teachers
{

    public class CreateController : ControllerBase
    {
        private readonly ITeachersRepository _teachersRepository;

        public CreateController(ITeachersRepository teachersRepository)
        {

            _teachersRepository = teachersRepository;
        }

        [HttpPost]
        [Route("api/TeachersCreate/")]
        public IActionResult CreateTeachers([FromBody] Teacher teacher)
        {
            try
            {
                _teachersRepository.Create(teacher);
                return Ok("Teacher has been created");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}