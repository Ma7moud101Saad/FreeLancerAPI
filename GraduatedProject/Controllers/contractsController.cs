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
    public class contractsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/contracts
        public IQueryable<contract> Getcontract()
        {
            return db.contract;
        }

        // GET: api/contracts/5
        [ResponseType(typeof(contract))]
        public IHttpActionResult Getcontract(int id)
        {
            contract contract = db.contract.Find(id);
            if (contract == null)
            {
                return NotFound();
            }

            return Ok(contract);
        }

        // PUT: api/contracts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcontract(int id, contract contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contract.ID)
            {
                return BadRequest();
            }

            db.Entry(contract).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!contractExists(id))
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

        // POST: api/contracts
        [ResponseType(typeof(contract))]
        public IHttpActionResult Postcontract(contract contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.contract.Add(contract);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contract.ID }, contract);
        }

        // DELETE: api/contracts/5
        [ResponseType(typeof(contract))]
        public IHttpActionResult Deletecontract(int id)
        {
            contract contract = db.contract.Find(id);
            if (contract == null)
            {
                return NotFound();
            }

            db.contract.Remove(contract);
            db.SaveChanges();

            return Ok(contract);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool contractExists(int id)
        {
            return db.contract.Count(e => e.ID == id) > 0;
        }
    }
}