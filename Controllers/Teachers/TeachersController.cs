using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Services;
using School.Services.Teachers;

namespace School.Controllers.Teachers
{

    public class TeachersController : ControllerBase
    {
        private readonly ITeachersRepository _teachersRepository;

        public TeachersController(ITeachersRepository teachersRepository)
        {

            _teachersRepository = teachersRepository;
        }

        [HttpGet]
        [Route("api/Teachers/")]
        public IActionResult GetAllTeachers()
        {
            try
            {
                var teachers = _teachersRepository.GetAll();
                return Ok(teachers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/Teachers/{id}")]
        public IActionResult GetTeacherById(int id)
        {

            try
            {
                var result = _teachersRepository.GetById(id);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}