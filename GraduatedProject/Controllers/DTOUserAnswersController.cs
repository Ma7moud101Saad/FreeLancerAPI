using GraduatedProject.DTO;
using GraduatedProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GraduatedProject.Controllers
{
   
    public class DTOUserAnswersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("PostUserAnswer")]
        public int PostUserAnswer(DTOUserAnswer dtoUsrAns)
        {
            Questions QuestionObj= db.Questions.FirstOrDefault(Q => Q.id == dtoUsrAns.QuestionID);
            test testObj = db.test.FirstOrDefault(t => t.id == dtoUsrAns.testId);
          
            FreeLancer freeLance = db.FreeLance.FirstOrDefault(F => F.ID == dtoUsrAns.FreeLancerId);
            int UserGrade = 0;
            if (dtoUsrAns.UserAnsw == QuestionObj.correctAnswer)
            {
                UserGrade = QuestionObj.degree;
             
            }
            else
            {
                UserGrade = 0;
               
            }
                UserAnswer usrAns = new UserAnswer()
            {
                UserAnsw =dtoUsrAns.UserAnsw,
                QuestionObj = QuestionObj,
                testobject = testObj,
                FreeLancerId = freeLance,
                Grad = UserGrade
             };
            db.UserAnswer.Add(usrAns);
            db.SaveChanges();
            return UserGrade;

        }
    }
}
