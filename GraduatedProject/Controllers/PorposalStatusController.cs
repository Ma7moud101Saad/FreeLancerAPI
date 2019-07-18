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
    public class PorposalStatusController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PorposalStatus
        public IQueryable<PorposalStatus> GetPorposalStatus()
        {
            return db.PorposalStatus;
        }

        // GET: api/PorposalStatus/5
        [ResponseType(typeof(PorposalStatus))]
        public IHttpActionResult GetPorposalStatus(int id)
        {
            PorposalStatus porposalStatus = db.PorposalStatus.Find(id);
            if (porposalStatus == null)
            {
                return NotFound();
            }

            return Ok(porposalStatus);
        }

        // PUT: api/PorposalStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPorposalStatus(int id, PorposalStatus porposalStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != porposalStatus.ID)
            {
                return BadRequest();
            }

            db.Entry(porposalStatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PorposalStatusExists(id))
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

        // POST: api/PorposalStatus
        [ResponseType(typeof(PorposalStatus))]
        public IHttpActionResult PostPorposalStatus(PorposalStatus porposalStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PorposalStatus.Add(porposalStatus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = porposalStatus.ID }, porposalStatus);
        }

        // DELETE: api/PorposalStatus/5
        [ResponseType(typeof(PorposalStatus))]
        public IHttpActionResult DeletePorposalStatus(int id)
        {
            PorposalStatus porposalStatus = db.PorposalStatus.Find(id);
            if (porposalStatus == null)
            {
                return NotFound();
            }

            db.PorposalStatus.Remove(porposalStatus);
            db.SaveChanges();

            return Ok(porposalStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PorposalStatusExists(int id)
        {
            return db.PorposalStatus.Count(e => e.ID == id) > 0;
        }
    }
}