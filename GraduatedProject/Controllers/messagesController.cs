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
    public class messagesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/messages
        public IQueryable<message> GetMessage()
        {
            return db.Message;
        }

        // GET: api/messages/5
        [ResponseType(typeof(message))]
        public IHttpActionResult Getmessage(int id)
        {
            message message = db.Message.Find(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // PUT: api/messages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmessage(int id, message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.Id)
            {
                return BadRequest();
            }

            db.Entry(message).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!messageExists(id))
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

        // POST: api/messages
        [ResponseType(typeof(message))]
        public IHttpActionResult Postmessage(message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Message.Add(message);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = message.Id }, message);
        }

        // DELETE: api/messages/5
        [ResponseType(typeof(message))]
        public IHttpActionResult Deletemessage(int id)
        {
            message message = db.Message.Find(id);
            if (message == null)
            {
                return NotFound();
            }

            db.Message.Remove(message);
            db.SaveChanges();

            return Ok(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool messageExists(int id)
        {
            return db.Message.Count(e => e.Id == id) > 0;
        }
    }
}