using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.Models;
using School.Data;
using Microsoft.EntityFrameworkCore;
using School.Services.Teachers;
//conectar al sql


namespace School.Services.Teachers
{
    public class TeachersRepository : ITeachersRepository
    {
        private readonly SchoolContext _teacherRepository;

        public TeachersRepository(SchoolContext teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        //create

        public void Create(Teacher teacher)
        {
            try
            {
                _teacherRepository.Teachers.Add(teacher);
                _teacherRepository.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Teacher can not created");
            }

        }

        //Getallteachers
        public IEnumerable<Teacher> GetAll()
        {
            try
            {
                var teachers = _teacherRepository.Teachers.ToList();
                return teachers;
            }
            catch (Exception r)
            {

                throw new Exception("Teachers not found");
            }
        }
        //ByIdTeacher
        public Teacher GetById(int id)
        {
            try
            {
                var teachers = _teacherRepository.Teachers.Find(id);
                if (teachers == null)
                {
                    throw new Exception("Teacher not found");
                }
                return teachers;
            }
            catch (Exception)
            {
                throw new Exception("Teacher not found");
            }
        }

        // public List<Teacher> GetAllCourses()
        // {
        //     var total = _teacherRepository.Teachers.Include(c => c.Course).ToList();
        //     return total;
        // }


        
        //UpdateTeacher
        public void Update(Teacher teacher)
        {
            try
            {
                var teachers = _teacherRepository.Teachers.FirstOrDefault(c => c.Id == teacher.Id);
                if (teachers != null)
                {
                    teachers.Names = teacher.Names;
                    teachers.Speciality = teacher.Speciality;
                    teachers.Phone = teacher.Phone;
                    teachers.Email = teacher.Email;
                    teachers.YearsExperience = teacher.YearsExperience;

                    _teacherRepository.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw new Exception("Teacher can not been update");
            }
        }


    }


}