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
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        // [JsonIgnore]
        // public List<Cita>? Citas {get; set;}
    }
}