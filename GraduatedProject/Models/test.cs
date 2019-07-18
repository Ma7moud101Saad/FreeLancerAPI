using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class test
    {
        public int id { get; set;}
        public string test_name { get; set; }
        [JsonIgnore]

        public ICollection<Questions> ListOfQuestions { get; set; }

    }
}