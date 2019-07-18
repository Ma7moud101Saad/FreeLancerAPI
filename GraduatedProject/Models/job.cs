using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class job
    {
        public int ID { get; set; }
        [ForeignKey("CategoryObj")]
        public int? CategoryId { get; set; }

        [ForeignKey("hire_managerObj")]
        public int? HireManagerId { get; set; }
        public string JopName { get; set; }
        public string  Description { get; set; }

        public DateTime JobDate { get; set; }
        [JsonIgnore]
        public payment_type PaymentTypeObj { get; set; }
        [JsonIgnore]
        public hire_manager hire_managerObj { get; set; }
        [JsonIgnore]
        public ICollection<proposal> proposalList { get; set; }
        [JsonIgnore]
        public ICollection<OtherSkills> OtherSkills { get; set; }
        [JsonIgnore]
        public complexity complexitityObj { get; set; }
        [JsonIgnore]
        public ICollection<ExpectedDuration> ExpectedDurationList { get; set; }
        [JsonIgnore]
        public Category CategoryObj { get; set; }
        [JsonIgnore]
        public Rate RateObj { get; set; }
    }
}