using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class hire_manager
    {
        public int Id { get; set; }
        public DateTime register_date { get; set; }
        public string location { get; set; }
        [JsonIgnore]
        public ApplicationUser UserObj { get; set; }
        [JsonIgnore]
        public company companyObj { get; set; }
        [JsonIgnore]
        public ICollection<job> jopList { get; set; }
    }
}