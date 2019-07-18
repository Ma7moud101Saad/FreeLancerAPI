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
    public class contactUsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/contactUs
        public IQueryable<contactUs> GetcontactUs()
        {
            return db.contactUs;
        }

        // GET: api/contactUs/5
        [ResponseType(typeof(contactUs))]
        public IHttpActionResult GetcontactUs(int id)
        {
            contactUs contactUs = db.contactUs.Find(id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return Ok(contactUs);
        }

        // PUT: api/contactUs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutcontactUs(int id, contactUs contactUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactUs.Id)
            {
                return BadRequest();
            }

            db.Entry(contactUs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!contactUsExists(id))
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

        // POST: api/contactUs
        [ResponseType(typeof(contactUs))]
        public IHttpActionResult PostcontactUs(contactUs contactUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.contactUs.Add(contactUs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactUs.Id }, contactUs);
        }

        // DELETE: api/contactUs/5
        [ResponseType(typeof(contactUs))]
        public IHttpActionResult DeletecontactUs(int id)
        {
            contactUs contactUs = db.contactUs.Find(id);
            if (contactUs == null)
            {
                return NotFound();
            }

            db.contactUs.Remove(contactUs);
            db.SaveChanges();

            return Ok(contactUs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool contactUsExists(int id)
        {
            return db.contactUs.Count(e => e.Id == id) > 0;
        }
    }
}