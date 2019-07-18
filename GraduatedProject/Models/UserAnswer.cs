using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class UserAnswer
    {
        public int id { get; set; }
        public bool UserAnsw { get; set; }
        public int Grad { get; set; }
        [JsonIgnore]
        public Questions QuestionObj { get; set; }
        [JsonIgnore]
        public test testobject { get; set; }
        
        [JsonIgnore]
        public FreeLancer FreeLancerId { get; set; }
    }
}