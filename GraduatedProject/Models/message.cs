using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class message
    {
        public int Id { get; set; }
        public DateTime messag_time { get; set; }
        public string message_text { get; set; }
        [JsonIgnore]
        public FreeLancer FreeLancerObj { get; set; }
        [JsonIgnore]
        public proposal proposalObj { get; set; }
        [JsonIgnore]
        public PorposalStatus PorposalStatusObj { get; set; }
        [JsonIgnore]
        public hire_manager hireManagerObj { get; set; }

    }
}