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
    public class hire_managerController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/hire_manager
        public IQueryable<hire_manager> Gethire_manager()
        {
            return db.hire_manager;
        }


        // GET: api/hire_manager/5
        [ResponseType(typeof(hire_manager))]
        public IHttpActionResult Gethire_manager(int id)
        {
            hire_manager hire_manager = db.hire_manager.Find(id);
            if (hire_manager == null)
            {
                return NotFound();
            }

            return Ok(hire_manager);
        }

        [Route("getHire/{UserId}")]
        public bool getHire(string UserId)
        {
            hire_manager obj = db.hire_manager.FirstOrDefault(H => H.UserObj.Id == UserId);
            if (obj != null)
                return true;
            else
                return false;
        }

        [Route("getHireId/{UserId}")]
        public int getHireId(string UserId)
        {
            hire_manager obj = db.hire_manager.FirstOrDefault(H => H.UserObj.Id == UserId);
            return obj.Id;
        }

        // PUT: api/hire_manager/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puthire_manager(int id, hire_manager hire_manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hire_manager.Id)
            {
                return BadRequest();
            }

            db.Entry(hire_manager).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hire_managerExists(id))
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

        // POST: api/hire_manager
        [ResponseType(typeof(hire_manager))]
        //public IHttpActionResult Posthire_manager(hire_manager hire_manager)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.hire_manager.Add(hire_manager);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = hire_manager.Id }, hire_manager);
        //}
        [Route("postHireManger")]
        public void PostHireManger(HireMangerDtop HMDto)
        {
           company cObj =  db.company.FirstOrDefault(c => c.ID == HMDto.companyObjID);
            ApplicationUser UObj = db.Users.FirstOrDefault(U => U.Id == HMDto.UserObjID);
            hire_manager newHireManger = new hire_manager() {
                register_date = DateTime.Now,
                location = HMDto.location,
                UserObj = UObj,
                companyObj = cObj
            };
            db.hire_manager.Add(newHireManger);
            db.SaveChanges();

        }

        // DELETE: api/hire_manager/5
        [ResponseType(typeof(hire_manager))]
        public IHttpActionResult Deletehire_manager(int id)
        {
            hire_manager hire_manager = db.hire_manager.Find(id);
            if (hire_manager == null)
            {
                return NotFound();
            }

            db.hire_manager.Remove(hire_manager);
            db.SaveChanges();

            return Ok(hire_manager);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool hire_managerExists(int id)
        {
            return db.hire_manager.Count(e => e.Id == id) > 0;
        }
    }
}