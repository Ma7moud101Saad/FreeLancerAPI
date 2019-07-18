using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class Questions
    {
        public int id { get; set; }
        public string Question { get; set; }

        public int degree { get; set; }
        public bool correctAnswer { get; set; }
        [JsonIgnore]
        public test test { get; set; }
    }
}