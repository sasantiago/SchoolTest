using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.Models;
using School.Data;
using Microsoft.EntityFrameworkCore;
using School.Services.Courses;



namespace School.Services.Courses
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly SchoolContext _courseRepository;

        public CoursesRepository(SchoolContext courseRepository)
        {
            _courseRepository = courseRepository;
        }
        //create

        public void Create(Course course)
        {
            try
            {
                _courseRepository.Courses.Add(course);
                _courseRepository.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Course can not created");
            }

        }

        //Getallteachers
        public IEnumerable<Course> GetAll()
        {
            try
            {
                var courses = _courseRepository.Courses.Include(c=>c.Teacher).ToList();
                return courses;
            }
            catch (Exception r)
            {

                throw new Exception("Courses not found");
            }
        }

    
        //ByIdTeacher
        public Course GetById(int id)
        {
            try
            {
                var courses = _courseRepository.Courses.FirstOrDefault(c=>c.Id==id);
                if (courses == null)
                {
                    throw new Exception("Teacher not found");
                }
                return courses;
            }
            catch (Exception)
            {
                throw new Exception("Teacher esta found");
            }
        }

        public IEnumerable<Course> GetAllByTeacher(int teacherId)

        {
            var total = _courseRepository.Courses.Where(c => c.TeacherId == teacherId).ToList();
            return total;
        }


        
        //UpdateTeacher
        public void Update(Course course)
        {
            try
            {
                var courses = _courseRepository.Courses.FirstOrDefault(c => c.Id == course.Id);
                if (courses != null)
                {
                    courses.Name = course.Name;
                    courses.Description = course.Description;
                    courses.TeacherId = course.TeacherId;
                    courses.Schedules = course.Schedules;
                    courses.Duration = course.Duration;
                    courses.Capacity = course.Capacity;
                    

                    _courseRepository.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw new Exception("Teacher can not been update");
            }
        }


    }


}