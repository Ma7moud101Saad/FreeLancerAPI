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
    public class JobSkillsController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        [Route("AddJobSkills")]
        public void AddFreelancerSkills(JobSkills JobSkill)
        {
            List<OtherSkills> ListOfSkills = new List<OtherSkills>();
            foreach (var item in JobSkill.listOfSkills)
            {
                OtherSkills newSkill = new OtherSkills
                {

                    skill_name = item
                };
                ListOfSkills.Add(newSkill);

            }
            job JobObj = context.job.FirstOrDefault(f => f.ID == JobSkill.JobId);

            JobObj.OtherSkills = ListOfSkills;
            context.SaveChanges();

        }
    }
}
