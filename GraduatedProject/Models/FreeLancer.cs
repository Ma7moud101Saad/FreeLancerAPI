using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class FreeLancer
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisterationDate { get; set; }
        public string Location { get; set; }
        public string OverView { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser UerAccountObj { get; set; }
        [JsonIgnore]
        public ICollection<certification> CertificationList { get; set; }
        [JsonIgnore]
        public ICollection<test_result>testResultList { get; set; }
        [JsonIgnore]
        public ICollection<message> MessageList { get; set; }
        [JsonIgnore]
        public ICollection<proposal> proposalList { get; set; }
        [JsonIgnore]
        public ICollection<contract> contractList { get; set; }
        [JsonIgnore]
        public ICollection<skill> skill { get; set; }

        [JsonIgnore]
        public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}