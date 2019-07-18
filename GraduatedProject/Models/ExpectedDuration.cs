using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class ExpectedDuration
    {
        public int ID { get; set; }
        public string DurationText { get; set; }
        [JsonIgnore]
        public job jobObj { get; set; }
    }
}