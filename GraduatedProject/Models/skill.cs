using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class skill
    {
        public int id { get; set; }
        public string skill_name { get; set; }
        [JsonIgnore]
        public  FreeLancer freeLancerObj { get; set; }
    
    }
}