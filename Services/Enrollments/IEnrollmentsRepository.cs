using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Data;
using School.Models;

namespace School.Services.Enrollments
{
    public interface IEnrollmentsRepository
    {
        IEnumerable<Enrollment> GetAll();
        IEnumerable<Enrollment> GetAllxDay(string date);
        IEnumerable<Enrollment> GetAllxStudent(string studentId);
        Enrollment GetById(int id);
        void Create(Enrollment enrollment);
        void Update(Enrollment enrollment);
        
    }
}