using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Data;
using School.Models;

namespace School.Services.Teachers
{
    public interface ITeachersRepository
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);
        void Create(Teacher teacher);
        void Update(Teacher teacher);
        
    }
}