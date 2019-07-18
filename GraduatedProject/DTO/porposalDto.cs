using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.DTO
{
    public class porposalDto
    {
        public float payment_amount { get; set; }
        public string freelancer_comment { get; set; }
        public int freeLancerObjId { get; set; }
        public int JobObjId { get; set; }

    }
}