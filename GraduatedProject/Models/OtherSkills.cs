using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class OtherSkills
    {
        public int id { get; set; }
        public string skill_name { get; set; }
      
        public job JobObj { get; set; }
    }
}