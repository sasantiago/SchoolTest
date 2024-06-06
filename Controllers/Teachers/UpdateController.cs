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

    public class UpdateController : ControllerBase
    {
        private readonly ITeachersRepository _teachersRepository;

        public UpdateController(ITeachersRepository teachersRepository)
        {

            _teachersRepository = teachersRepository;
        }

        [HttpPut]
        [Route("api/TeachersUpdate/{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] Teacher teacher)
        {

            if (!ModelState.IsValid)
                return BadRequest("Data empty !");

            try
            {
                var resulteacher = _teachersRepository.GetById(id);
                if (resulteacher == null)
                {
                    return NotFound($"not found this Teacher with this id {id}");
                }
                _teachersRepository.Update(teacher);
                return Ok("Teacher is updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}