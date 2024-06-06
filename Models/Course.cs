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
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        [Required]
        public string Schedules { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public int Capacity { get; set; }
        
        // [JsonIgnore]
        // public List<Cita>? Citas {get; set;}
    }
}