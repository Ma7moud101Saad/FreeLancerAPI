using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraduatedProject.Models
{
    public class contactUs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Subject { get; set; }
        
        public string Message { get; set; }
    }
}