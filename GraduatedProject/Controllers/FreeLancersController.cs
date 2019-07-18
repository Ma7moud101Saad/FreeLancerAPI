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
using GraduatedProject.DTO;
namespace GraduatedProject.Controllers
{
    public class FreeLancersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/FreeLancers
        public IQueryable<FreeLancer> GetFreeLance()
        {
            return db.FreeLance;
        }

        // GET: api/FreeLancers/5
        [ResponseType(typeof(FreeLancer))]
        public IHttpActionResult GetFreeLancer(int id)
        {
            FreeLancer freeLancer = db.FreeLance.Find(id);
            if (freeLancer == null)
            {
                return NotFound();
            }

            return Ok(freeLancer);
        }


        //check if this user Has freelancer Account or not

        [Route("getFree/{UserId}")]
        public bool getFree(string UserId)
        {
            FreeLancer obj = db.FreeLance.FirstOrDefault(f => f.UerAccountObj.Id == UserId);
            if (obj != null)
                return true;
            else
                return false;
        }


        //take UserId Id And Return FreeLancerID
        [Route("getFreeID/{UserId}")]
        public int getFreeID(string UserId)
        {
            FreeLancer obj = db.FreeLance.FirstOrDefault(f => f.UerAccountObj.Id == UserId);
            return obj.ID;
        }
        // PUT: api/FreeLancers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFreeLancer(int id, FreeLancer freeLancer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != freeLancer.ID)
            {
                return BadRequest();
            }

            db.Entry(freeLancer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FreeLancerExists(id))
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

        // POST: api/FreeLancers
        [ResponseType(typeof(FreeLancer))]
        //public IHttpActionResult PostFreeLancer(FreeLancer freeLancer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.FreeLance.Add(freeLancer);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = freeLancer.ID }, freeLancer);
        //}


        [Route("postUser")]
        public string postUser(UserEmail EmailObj)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ApplicationUser userObj = db.Users.FirstOrDefault(u => u.Email == EmailObj.Email);
            return userObj.Id;

        }
        [Route("PostFreeLancer")]
        public int postFreelancer(FreeLancerDto freeLancDt)
        {
            ApplicationUser userObj = db.Users.FirstOrDefault(u => u.Id == freeLancDt.UerAccountID);
            FreeLancer newFreeLancer = new FreeLancer()
            {
                RegisterationDate = DateTime.Now,
                Location = freeLancDt.Location,
                OverView = freeLancDt.OverView,
                UerAccountObj = userObj
            };
            db.FreeLance.Add(newFreeLancer);
            db.SaveChanges();
            FreeLancer FreeLancerLastAdded = db.FreeLance.OrderByDescending(f => f.ID).FirstOrDefault();
            return FreeLancerLastAdded.ID;


        }
        // DELETE: api/FreeLancers/5
        [ResponseType(typeof(FreeLancer))]
        public IHttpActionResult DeleteFreeLancer(int id)
        {
            FreeLancer freeLancer = db.FreeLance.Find(id);
            if (freeLancer == null)
            {
                return NotFound();
            }

            db.FreeLance.Remove(freeLancer);
            db.SaveChanges();

            return Ok(freeLancer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FreeLancerExists(int id)
        {
            return db.FreeLance.Count(e => e.ID == id) > 0;
        }
    }
}