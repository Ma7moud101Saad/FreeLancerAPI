using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class attachment
    {
        public int ID { get; set; }
        public string attachmentLink { get; set; }
        [JsonIgnore]
        public message MessageObj { get; set; }
    }
}