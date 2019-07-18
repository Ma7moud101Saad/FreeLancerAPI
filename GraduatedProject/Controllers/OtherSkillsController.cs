using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GraduatedProject.Models;

namespace GraduatedProject.Controllers
{
    public class OtherSkillsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/OtherSkills
        public IQueryable<OtherSkills> GetOtherSkills()
        {
            return db.OtherSkills;
        }

        // GET: api/OtherSkills/5
        [ResponseType(typeof(OtherSkills))]
        public IHttpActionResult GetOtherSkills(int id)
        {
            OtherSkills otherSkills = db.OtherSkills.Find(id);
            if (otherSkills == null)
            {
                return NotFound();
            }

            return Ok(otherSkills);
        }

        [Route("GetSkillOfJob/{JobId}")]
        public List<OtherSkills> GetAllSkillsOfJob(int JobId)
        {


            List<OtherSkills> ListOfOtherSkills = db.OtherSkills.Where(O => O.JobObj.ID == JobId).ToList();
            return ListOfOtherSkills;

        }

        // PUT: api/OtherSkills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOtherSkills(int id, OtherSkills otherSkills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != otherSkills.id)
            {
                return BadRequest();
            }

            db.Entry(otherSkills).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherSkillsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OtherSkills
        [ResponseType(typeof(OtherSkills))]
        public IHttpActionResult PostOtherSkills(OtherSkills otherSkills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OtherSkills.Add(otherSkills);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = otherSkills.id }, otherSkills);
        }

        // DELETE: api/OtherSkills/5
        [ResponseType(typeof(OtherSkills))]
        public IHttpActionResult DeleteOtherSkills(int id)
        {
            OtherSkills otherSkills = db.OtherSkills.Find(id);
            if (otherSkills == null)
            {
                return NotFound();
            }

            db.OtherSkills.Remove(otherSkills);
            db.SaveChanges();

            return Ok(otherSkills);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OtherSkillsExists(int id)
        {
            return db.OtherSkills.Count(e => e.id == id) > 0;
        }
    }
}