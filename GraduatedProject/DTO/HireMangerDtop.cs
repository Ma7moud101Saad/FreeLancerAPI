using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.DTO
{
    public class HireMangerDtop
    {
        public int Id { get; set; }
        public DateTime register_date { get; set; }
        public string location { get; set; }
        
        public string UserObjID { get; set; }
  
        public int companyObjID { get; set; }
    }
}