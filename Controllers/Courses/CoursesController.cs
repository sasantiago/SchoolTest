using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Services;
using School.Services.Courses;

namespace School.Controllers.Courses
{
    
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesController(ICoursesRepository coursesRepositor){

            _coursesRepository = coursesRepositor;
        }

        [HttpGet] 
        [Route("api/Courses/")]
        public IActionResult GetAllTeachers(){
            try
            {
                var courses = _coursesRepository.GetAll();
                return Ok(courses);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/Courses/{id}")]
        public IActionResult GetCoursesById(int id){
            
            try{
                var result =  _coursesRepository.GetById(id);
                return Ok(result);

            }  catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("api/Courses/teachers/{TeacherId}/courses")]
        public IActionResult GetCoursesByTeacherId(int teacherId){
            try{
                var result = _coursesRepository.GetAllByTeacher(teacherId);
                return Ok(result);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        
    }
}