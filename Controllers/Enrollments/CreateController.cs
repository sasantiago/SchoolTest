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

    public class CreateController : ControllerBase
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public CreateController(IEnrollmentsRepository enrollmentsRepository)
        {

            _enrollmentsRepository = enrollmentsRepository;
        }

        [HttpPost]
        [Route("api/CreateEnrollments/")]
        
        public IActionResult CreateTeachers([FromBody] Enrollment enrollment)
        {
            try
            {
                _enrollmentsRepository.Create(enrollment);
                return Ok("Enrollment has been created");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

    }
}