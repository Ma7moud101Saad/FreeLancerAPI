using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.DTO
{
    public class PorposalWithName
    {
        public DateTime proposal_time { get; set; }
        public float? payment_amount { get; set; }
        public string freelancer_comment { get; set; }
    }
}