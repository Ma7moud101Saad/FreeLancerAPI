using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class contract
    {
        public int ID { get; set; }
        public double PaymentAmount { get; set; }
        [DataType(DataType.Date)]
        public DateTime startTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }
        [JsonIgnore]
        public FreeLancer FreeLancerObj { get; set; }
        [JsonIgnore]
        public payment_type payment_type { get; set; }
        [JsonIgnore]
        public proposal proposalObj { get; set; }
        [JsonIgnore]
        public hire_manager hire_managerObj { get; set; }
    }
}