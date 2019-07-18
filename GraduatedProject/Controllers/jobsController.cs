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
    public class jobsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/jobs
        public IQueryable<job> Getjob()
        {
            return db.job;
        }


        //Get Job with Name
        [Route("GetJobWithName/{name}")]
        public List<job> GetjobWithName(string name)
        {
            return db.job.Where(J => J.JopName.Contains(name)).ToList();
        }


        [Route("GetJob/{id}")]
        public job GetJobById(int id)
        {
          job JobObject =  db.job.FirstOrDefault(J => J.ID == id);
            return JobObject;
        }

        // GET: api/jobs/5
        [ResponseType(typeof(job))]
        public IHttpActionResult Getjob(int id)
        {
            job job = db.job.Find(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT: api/jobs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putjob(int id, job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.ID)
            {
                return BadRequest();
            }

            db.Entry(job).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!jobExists(id))
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

        // POST: api/jobs
        [ResponseType(typeof(job))]
        //public IHttpActionResult Postjob(job job)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.job.Add(job);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = job.ID }, job);
        //}
        [Route("postJob")]
        public int postJob(job jobObj)
        {
            db.job.Add(jobObj);
            db.SaveChanges();
            job jobLastAdded = db.job.OrderByDescending(j => j.ID).FirstOrDefault();
            return jobLastAdded.ID;
        }
        // DELETE: api/jobs/5
        [ResponseType(typeof(job))]
        public IHttpActionResult Deletejob(int id)
        {
            job job = db.job.Find(id);
            if (job == null)
            {
                return NotFound();
            }

            db.job.Remove(job);
            db.SaveChanges();

            return Ok(job);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool jobExists(int id)
        {
            return db.job.Count(e => e.ID == id) > 0;
        }
    }
}