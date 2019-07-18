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
    public class testsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/tests
        public IQueryable<test> Gettest()
        {
            return db.test;
        }
        [Route("GetTestById/{id}")]
        public test GetTestById(int id)
        {
           test testObj= db.test.FirstOrDefault(t => t.id == id);
            return testObj;
        }

        // GET: api/tests/5
        [ResponseType(typeof(test))]
        public IHttpActionResult Gettest(int id)
        {
            test test = db.test.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        // PUT: api/tests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttest(int id, test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test.id)
            {
                return BadRequest();
            }

            db.Entry(test).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testExists(id))
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

        // POST: api/tests
        [ResponseType(typeof(test))]
        [Route("AddTest")]
        public int Posttest(test test)
        {
            db.test.Add(test);
            db.SaveChanges();
           test testLastAdded = db.test.OrderByDescending(t => t.id).FirstOrDefault();
            return testLastAdded.id;

        }
        //public IHttpActionResult Posttest(test test)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.test.Add(test);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = test.id }, test);
        //}

        // DELETE: api/tests/5
        [ResponseType(typeof(test))]
        public IHttpActionResult Deletetest(int id)
        {
            test test = db.test.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            db.test.Remove(test);
            db.SaveChanges();

            return Ok(test);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool testExists(int id)
        {
            return db.test.Count(e => e.id == id) > 0;
        }
    }
}