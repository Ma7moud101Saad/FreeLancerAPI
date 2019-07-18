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
    public class complexitiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/complexities
        public IQueryable<complexity> Getcomplexity()
        {
            return db.complexity;
        }

        // GET: api/complexities/5
        [ResponseType(typeof(complexity))]
        public IHttpActionResult Getcomplexity(int id)
        {
            complexity complexity = db.complexity.Find(id);
            if (complexity == null)
            {
                return NotFound();
            }

            return Ok(complexity);
        }

        // PUT: api/complexities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcomplexity(int id, complexity complexity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complexity.ID)
            {
                return BadRequest();
            }

            db.Entry(complexity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!complexityExists(id))
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

        // POST: api/complexities
        [ResponseType(typeof(complexity))]
        public IHttpActionResult Postcomplexity(complexity complexity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.complexity.Add(complexity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = complexity.ID }, complexity);
        }

        // DELETE: api/complexities/5
        [ResponseType(typeof(complexity))]
        public IHttpActionResult Deletecomplexity(int id)
        {
            complexity complexity = db.complexity.Find(id);
            if (complexity == null)
            {
                return NotFound();
            }

            db.complexity.Remove(complexity);
            db.SaveChanges();

            return Ok(complexity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool complexityExists(int id)
        {
            return db.complexity.Count(e => e.ID == id) > 0;
        }
    }
}