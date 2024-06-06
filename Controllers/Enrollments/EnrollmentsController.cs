using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Services;
using School.Services.Enrollments;

namespace School.Controllers.Enrollments
{

    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public EnrollmentsController(IEnrollmentsRepository enrollmentsRepository)
        {

            _enrollmentsRepository = enrollmentsRepository;
        }

        [HttpGet]
        [Route("api/Enrollments/")]
        public IActionResult GetAllENrollments()
        {
            try
            {
                var enrollments = _enrollmentsRepository.GetAll();
                return Ok(enrollments);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/Enrollments/{id}")]
        public IActionResult GetTeacherById(int id)
        {

            try
            {
                var result = _enrollmentsRepository.GetById(id);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("api/Enrollments/GetAllxDay/{Date}")]
        public IActionResult GetAllxDay (string date){
            try
            {
                var result = _enrollmentsRepository.GetAllxDay(date);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("api/Enrollments/GetAllxStudents/{Id}")]
        public IActionResult GetAllxStudens (string Id){
            try
            {
                var result = _enrollmentsRepository.GetAllxStudent(Id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}