using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services;
using School.Services.Enrollments;

namespace School.Controllers.Enrollments
{

    public class UpdateController : ControllerBase
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public UpdateController(IEnrollmentsRepository enrollmentsRepository)
        {

            _enrollmentsRepository = enrollmentsRepository;
        }
        [HttpPut]
        [Route("api/UpdateEnrollment/{id}")]
        public IActionResult UpdateEnrollment(int id, [FromBody] Enrollment enrollment)
        {

            if (!ModelState.IsValid)
                return BadRequest("Data empty !");

            try
            {
                var resulteacher = _enrollmentsRepository.GetById(id);
                if (resulteacher == null)
                {
                    return NotFound($"not found this Teacher with this id {id}");
                }
                _enrollmentsRepository.Update(enrollment);
                return Ok("Student is updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

    }
}