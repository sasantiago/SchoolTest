using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.Models;
using School.Data;
using Microsoft.EntityFrameworkCore;
using School.Services;



namespace School.Services.Enrollments
{
    public class EnrollmentsRepository : IEnrollmentsRepository
    {
        private readonly SchoolContext _enrollmentsRepository;

        public EnrollmentsRepository(SchoolContext enrollmentsRepository)
        {
            _enrollmentsRepository = enrollmentsRepository;
        }
        //create

        public void Create(Enrollment enrollment)
        {
            try
            {
                enrollment.Status = "pendiente de pago";
                _enrollmentsRepository.Enrollments.Add(enrollment);
                _enrollmentsRepository.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Enrollment can not created");
            }

        }

        //GetallEnrollments
        public IEnumerable<Enrollment> GetAll()
        {
            try
            {
                var enrollments = _enrollmentsRepository.Enrollments.ToList();
                return enrollments;
            }
            catch (Exception r)
            {

                throw new Exception("Enrollment not found");
            }
        }

        public IEnumerable<Enrollment> GetAllxDay(string date)
        {
            try
            {

                var enrollments = _enrollmentsRepository.Enrollments
                   .Where(c => c.Dates.ToString("yyyy-MM-dd") == date)
                   .Include(c => c.Student)
                   .ToList();

                return (IEnumerable<Enrollment>)enrollments.Select(c => c.Student);
            }
            catch
            {
                throw new Exception("Enrollment per Day not found");
            }
        }

        public IEnumerable<Enrollment> GetAllxStudent(string studentId)
        {
            try
            {
                var enrollments = _enrollmentsRepository.Enrollments.Where(m => m.StudentId.ToString() == studentId)
                   .Include(m => m.Student)
                   .ToList();

                return enrollments;
            }
            catch
            {
                throw new Exception("Enrollment per Student not found");
            }
        }





        //ByIdEnrollment
        public Enrollment GetById(int id)
        {
            try
            {
                var student = _enrollmentsRepository.Enrollments.Find(id);
                if (student == null)
                {
                    throw new Exception("Enrollment not found");
                }
                return student;
            }
            catch (Exception)
            {
                throw new Exception("Enrollment not found");
            }
        }



        //UpdateEnrollment
        public void Update(Enrollment enrollment)
        {
            try
            {
                var enrollments = _enrollmentsRepository.Enrollments.FirstOrDefault(c => c.Id == enrollment.Id);
                if (enrollments != null)
                {
                    enrollments.Dates = enrollment.Dates;
                    enrollments.StudentId = enrollment.StudentId;
                    enrollments.CourseId = enrollment.CourseId;
                    enrollments.Status = enrollment.Status;

                    _enrollmentsRepository.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw new Exception("Teacher can not been update");
            }
        }

    
    }


}