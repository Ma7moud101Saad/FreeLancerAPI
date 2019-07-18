using GraduatedProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GraduatedProject.DTO;
namespace GraduatedProject.Controllers
{
    public class AddQuestionToTestController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        [Route("AddQuestionToTest")]
        public void postQustion(AddQuestionToTest QustionTest)
        {
          
           test testAdded= db.test.FirstOrDefault(t => t.id == QustionTest.TestId);
            Questions NewQuestion = new Questions
            {
                Question = QustionTest.Question,
                degree = QustionTest.degree,
                correctAnswer = QustionTest.correctAnswer,
                test = testAdded


            };
            db.Questions.Add(NewQuestion);
            db.SaveChanges();
            
            
            
               
        }
    }
}
