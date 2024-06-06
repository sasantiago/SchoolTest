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
    public class Enrollment
    {
        public int Id { get; set; }
        [Required]
        public DateTime Dates { get; set; }
        [Required]
        public DateTime StudentId { get; set; }
        public Student? Student {get;set;}
        [Required]
        public string CourseId { get; set; }
        public Course? Course {get;set;}
        [Required]
        public string Status { get; set; }
        // [JsonIgnore]
        // public List<Cita>? Citas {get; set;}
    }
}