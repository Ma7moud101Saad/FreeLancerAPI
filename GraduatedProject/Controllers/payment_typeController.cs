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
    public class payment_typeController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/payment_type
        public IQueryable<payment_type> Getpayment_type()
        {
            return db.payment_type;
        }

        // GET: api/payment_type/5
        [ResponseType(typeof(payment_type))]
        public IHttpActionResult Getpayment_type(int id)
        {
            payment_type payment_type = db.payment_type.Find(id);
            if (payment_type == null)
            {
                return NotFound();
            }

            return Ok(payment_type);
        }

        // PUT: api/payment_type/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpayment_type(int id, payment_type payment_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payment_type.Id)
            {
                return BadRequest();
            }

            db.Entry(payment_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!payment_typeExists(id))
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

        // POST: api/payment_type
        [ResponseType(typeof(payment_type))]
        public IHttpActionResult Postpayment_type(payment_type payment_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.payment_type.Add(payment_type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = payment_type.Id }, payment_type);
        }

        // DELETE: api/payment_type/5
        [ResponseType(typeof(payment_type))]
        public IHttpActionResult Deletepayment_type(int id)
        {
            payment_type payment_type = db.payment_type.Find(id);
            if (payment_type == null)
            {
                return NotFound();
            }

            db.payment_type.Remove(payment_type);
            db.SaveChanges();

            return Ok(payment_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool payment_typeExists(int id)
        {
            return db.payment_type.Count(e => e.Id == id) > 0;
        }
    }
}