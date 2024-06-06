using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Data;
using School.Models;

namespace School.Services.Students
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetAllByBirthDay(string Birthday);
        Student GetById(int id);
        void Create(Student student);
        void Update(Student student);
        
    }
}