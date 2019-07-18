using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class proposal
    {

        public int id { get; set; }
        public DateTime proposal_time { get; set; }
        public float? payment_amount { get; set; }
        public int? current_proposal_status { get; set; }
        public string client_comment { get; set; }
        public int? freelancer_grade { get; set; }
        public int? client_grade { get; set; }
        public string freelancer_comment { get; set; }
        [JsonIgnore]
        public virtual FreeLancer FreeLancerObj { get; set; }
        [JsonIgnore]
        public ICollection<message> MessageList { get; set; }
        [JsonIgnore]
        public PorposalStatus PorposalStatusObj { get; set; }
        [JsonIgnore]
        public job JobObj { get; set; }

    }
}