using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class test_result
    {

     public int id { get; set; }
     public DateTime Test_time { get; set; }
     public string test_Name { get; set; }
     public int score { get; set; }
     [JsonIgnore]
     public FreeLancer FreeLancerObj { get; set; }
     [JsonIgnore]
     public test testObj { get; set; }
        
    }
}