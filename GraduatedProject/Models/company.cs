using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        [JsonIgnore]
        public virtual ICollection<hire_manager> hire_managerObj { get; set; }

        [JsonIgnore]
        public ApplicationUser UserObj { get; set; }
    }
}