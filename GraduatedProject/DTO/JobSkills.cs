using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.DTO
{
    public class JobSkills
    {
        public int JobId { get; set; }
        public List<string> listOfSkills { get; set; } = new List<string>();
    }
}