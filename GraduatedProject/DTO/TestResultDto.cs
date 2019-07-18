using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.DTO
{
    public class TestResultDto
    {
        public int id { get; set; }
        public DateTime Test_time { get; set; }
        public string test_Name { get; set; }
        public int score { get; set; }
    
        public int FreeLancerObjId { get; set; }
    
        public int testObjId { get; set; }
    }
}