using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.DTO
{
    public class DTOUserAnswer
    {
        public bool UserAnsw { get; set; }
        public int QuestionID { get; set; }
        public int testId { get; set; }
        public int FreeLancerId { get; set; }
    }
}