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
    public class ExpectedDurationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ExpectedDurations
        public IQueryable<ExpectedDuration> GetExpectedDuration()
        {
            return db.ExpectedDuration;
        }

        // GET: api/ExpectedDurations/5
        [ResponseType(typeof(ExpectedDuration))]
        public IHttpActionResult GetExpectedDuration(int id)
        {
            ExpectedDuration expectedDuration = db.ExpectedDuration.Find(id);
            if (expectedDuration == null)
            {
                return NotFound();
            }

            return Ok(expectedDuration);
        }

        // PUT: api/ExpectedDurations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExpectedDuration(int id, ExpectedDuration expectedDuration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expectedDuration.ID)
            {
                return BadRequest();
            }

            db.Entry(expectedDuration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpectedDurationExists(id))
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

        // POST: api/ExpectedDurations
        [ResponseType(typeof(ExpectedDuration))]
        public IHttpActionResult PostExpectedDuration(ExpectedDuration expectedDuration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExpectedDuration.Add(expectedDuration);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = expectedDuration.ID }, expectedDuration);
        }

        // DELETE: api/ExpectedDurations/5
        [ResponseType(typeof(ExpectedDuration))]
        public IHttpActionResult DeleteExpectedDuration(int id)
        {
            ExpectedDuration expectedDuration = db.ExpectedDuration.Find(id);
            if (expectedDuration == null)
            {
                return NotFound();
            }

            db.ExpectedDuration.Remove(expectedDuration);
            db.SaveChanges();

            return Ok(expectedDuration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpectedDurationExists(int id)
        {
            return db.ExpectedDuration.Count(e => e.ID == id) > 0;
        }
    }
}