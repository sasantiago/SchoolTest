using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.Models;
using School.Data;
using Microsoft.EntityFrameworkCore;
using School.Services.Students;



namespace School.Services.Students
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly SchoolContext _studentRepository;

        public StudentsRepository(SchoolContext studentRepository)
        {
            _studentRepository = studentRepository;
        }
        //create

        public void Create(Student student)
        {
            try
            {
                _studentRepository.Students.Add(student);
                _studentRepository.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Students can not created");
            }

        }

        //Getallteachers
        public IEnumerable<Student> GetAll()
        {
            try
            {
                var students = _studentRepository.Students.ToList();
                return students;
            }
            catch (Exception r)
            {

                throw new Exception("Students not found");
            }
        }

        public IEnumerable<Student> GetAllByBirthDay(string Birthday)
        {
            var daynote = _studentRepository.Students.Where(c => c.Birthday.ToString("yyyy-MM-dd") == Birthday).ToList();
            return daynote;
        }

        //ByIdTeacher
        public Student GetById(int id)
        {
            try
            {
                var student = _studentRepository.Students.Find(id);
                if (student == null)
                {
                    throw new Exception("Teacher not found");
                }
                return student;
            }
            catch (Exception)
            {
                throw new Exception("Teacher not found");
            }
        }



        //UpdateTeacher
        public void Update(Student student)
        {
            try
            {
                var students = _studentRepository.Students.FirstOrDefault(c => c.Id == student.Id);
                if (students != null)
                {
                    students.Names = student.Names;
                    students.Birthday = student.Birthday;
                    students.Address = student.Address;
                    students.Email = student.Email;

                    _studentRepository.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw new Exception("Teacher can not been update");
            }
        }


    }


}