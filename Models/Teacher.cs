using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using School.Data;
using School.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace School.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]
        public string Speciality { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int YearsExperience { get; set; }

        // public List<Cita>? Citas {get; set;}
    }
}