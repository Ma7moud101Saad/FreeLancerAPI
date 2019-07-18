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
    public class certificationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/certifications
        public IQueryable<certification> Getcertification()
        {
            return db.certification;
        }

        // GET: api/certifications/5
        [ResponseType(typeof(certification))]
        public IHttpActionResult Getcertification(int id)
        {
            certification certification = db.certification.Find(id);
            if (certification == null)
            {
                return NotFound();
            }

            return Ok(certification);
        }

        // PUT: api/certifications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcertification(int id, certification certification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != certification.Id)
            {
                return BadRequest();
            }

            db.Entry(certification).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!certificationExists(id))
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

        // POST: api/certifications
        [ResponseType(typeof(certification))]
        public IHttpActionResult Postcertification(certification certification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.certification.Add(certification);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = certification.Id }, certification);
        }

        // DELETE: api/certifications/5
        [ResponseType(typeof(certification))]
        public IHttpActionResult Deletecertification(int id)
        {
            certification certification = db.certification.Find(id);
            if (certification == null)
            {
                return NotFound();
            }

            db.certification.Remove(certification);
            db.SaveChanges();

            return Ok(certification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool certificationExists(int id)
        {
            return db.certification.Count(e => e.Id == id) > 0;
        }
    }
}