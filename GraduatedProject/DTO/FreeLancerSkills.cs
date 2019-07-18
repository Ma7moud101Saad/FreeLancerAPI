using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduatedProject.Models;
namespace GraduatedProject.DTO
{
    public class FreeLancerSkills
    {
        public int FreeLancerID { get; set; }
        public List<string> listOfSkills { get; set; }= new List<string>();
    }
}