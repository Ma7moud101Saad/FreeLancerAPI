using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CatName { get; set; }
        public string ImageName { get; set; }
        [JsonIgnore]
        public ICollection<job> jobs { get; set; }
    }
}