using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduatedProject.DTO
{
    public class AddQuestionToTest
    {
        public string Question { get; set; }

        public int degree { get; set; }
        public int TestId { get; set; }
        public bool correctAnswer { get; set; }
    }
}