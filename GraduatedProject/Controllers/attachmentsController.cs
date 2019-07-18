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
    public class attachmentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/attachments
        public IQueryable<attachment> Getattachment()
        {
            return db.attachment;
        }

        // GET: api/attachments/5
        [ResponseType(typeof(attachment))]
        public IHttpActionResult Getattachment(int id)
        {
            attachment attachment = db.attachment.Find(id);
            if (attachment == null)
            {
                return NotFound();
            }

            return Ok(attachment);
        }

        // PUT: api/attachments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putattachment(int id, attachment attachment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attachment.ID)
            {
                return BadRequest();
            }

            db.Entry(attachment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!attachmentExists(id))
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

        // POST: api/attachments
        [ResponseType(typeof(attachment))]
        public IHttpActionResult Postattachment(attachment attachment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.attachment.Add(attachment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = attachment.ID }, attachment);
        }

        // DELETE: api/attachments/5
        [ResponseType(typeof(attachment))]
        public IHttpActionResult Deleteattachment(int id)
        {
            attachment attachment = db.attachment.Find(id);
            if (attachment == null)
            {
                return NotFound();
            }

            db.attachment.Remove(attachment);
            db.SaveChanges();

            return Ok(attachment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool attachmentExists(int id)
        {
            return db.attachment.Count(e => e.ID == id) > 0;
        }
    }
}