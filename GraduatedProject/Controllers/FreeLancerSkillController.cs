using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GraduatedProject.DTO;
using GraduatedProject.Models;

namespace GraduatedProject.Controllers
{
    public class FreeLancerSkillController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        [Route("AddSkills")]
        public void AddFreelancerSkills(FreeLancerSkills FreeSkill)
        {
            List<skill> ListOfSkills = new List<skill>();
            foreach (var item in FreeSkill.listOfSkills)
            {
                skill newSkill = new skill
                {

                    skill_name = item
                };
                ListOfSkills.Add(newSkill);

            }
            FreeLancer freeLanceObj = context.FreeLance.FirstOrDefault(f => f.ID == FreeSkill.FreeLancerID);

            freeLanceObj.skill = ListOfSkills;
            context.SaveChanges();

        }
    }
}
