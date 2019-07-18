using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class certification
    {
        public int Id { get; set; }
        public string certification_name { get; set; }
        public string  provider { get; set; }
        public string  description { get; set; }
        public DateTime date_earned { get; set; }
        public string certification_link { get; set; }
        [JsonIgnore]
        public FreeLancer FreeLancerObj { get; set; }

    }
}