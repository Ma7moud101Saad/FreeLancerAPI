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
    public class companiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/companies
        public IQueryable<company> Getcompany()
        {
            return db.company;
        }

        // GET: api/companies/5
        [ResponseType(typeof(company))]
        public IHttpActionResult Getcompany(int id)
        {
            company company = db.company.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [Route("getCompany/{UserId}")]
        public bool getHire(string UserId)
        {
            company obj = db.company.FirstOrDefault(C => C.UserObj.Id == UserId);
            if (obj != null)
                return true;
            else
                return false;
        }

        // PUT: api/companies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcompany(int id, company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.ID)
            {
                return BadRequest();
            }

            db.Entry(company).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!companyExists(id))
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

        // POST: api/companies
        [ResponseType(typeof(company))]
        //public IHttpActionResult Postcompany(company company)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.company.Add(company);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = company.ID }, company);
        //}

        [Route("PostCompany")]
        public void PostCompany(CompanyDto CoDto)
        {
          ApplicationUser UObj =  db.Users.FirstOrDefault(U => U.Id == CoDto.UerAccountID);
            company NewCompay = new company() {
                    CompanyName = CoDto.CompanyName,
                    CompanyLocation = CoDto.CompanyLocation,
                    UserObj= UObj
            };

            db.company.Add(NewCompay);
            db.SaveChanges();


        }
        // DELETE: api/companies/5
        [ResponseType(typeof(company))]
        public IHttpActionResult Deletecompany(int id)
        {
            company company = db.company.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            db.company.Remove(company);
            db.SaveChanges();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool companyExists(int id)
        {
            return db.company.Count(e => e.ID == id) > 0;
        }
    }
}