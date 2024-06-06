using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Data;
using School.Models;

namespace School.Services.Courses
{
    public interface ICoursesRepository
    {
        IEnumerable<Course> GetAll();
        IEnumerable<Course> GetAllByTeacher(int teacherId);
        Course GetById(int id);
        void Create(Course course);
        void Update(Course course);
        
    }
}