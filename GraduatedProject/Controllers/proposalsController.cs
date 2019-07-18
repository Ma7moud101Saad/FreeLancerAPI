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
    public class proposalsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/proposals
        public IQueryable<proposal> Getproposal()
        {
            return db.proposal;
        }

        
        // GET: api/proposals/5
        [ResponseType(typeof(proposal))]
        public IHttpActionResult Getproposal(int id)
        {
            proposal proposal = db.proposal.Find(id);
            if (proposal == null)
            {
                return NotFound();
            }

            return Ok(proposal);
        }

        //-----------------GetDtoPorposal---------------------------------
        [Route("GetPorposal/{JobID}")]
        public List<NameWithPorposalDto> GetNameWithPorposalDto(int JobID)
        {
            List<NameWithPorposalDto> ListOfNameWithPorposalDto = new List<NameWithPorposalDto>();
            List<proposal> ListOfproposal = db.proposal.Where(p => p.JobObj.ID == JobID).OrderByDescending(p=>p.proposal_time).ToList();
            foreach (var item in ListOfproposal)
            {
                NameWithPorposalDto NameWithPorposalDtoObj = new NameWithPorposalDto();

                FreeLancer freeLancerObj = db.FreeLance.FirstOrDefault(f => f.ID == item.FreeLancerObj.ID);
                NameWithPorposalDtoObj.userName = freeLancerObj.UerAccountObj.FirstName +" "+ freeLancerObj.UerAccountObj.LastName;
                NameWithPorposalDtoObj.Email = freeLancerObj.UerAccountObj.Email;
                NameWithPorposalDtoObj.PaymentAmount = item.payment_amount.Value;
                NameWithPorposalDtoObj.porposal = item.freelancer_comment;

                ListOfNameWithPorposalDto.Add(NameWithPorposalDtoObj);                
            }
            return ListOfNameWithPorposalDto;
        }

        //----------------end of GerDtoPorposal---------------------------

        // PUT: api/proposals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproposal(int id, proposal proposal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proposal.id)
            {
                return BadRequest();
            }

            db.Entry(proposal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!proposalExists(id))
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

        // POST: api/proposals
        [ResponseType(typeof(proposal))]
        //public IHttpActionResult Postproposal(proposal proposal)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.proposal.Add(proposal);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = proposal.id }, proposal);
        //}

        [Route("AddPorposal")]
        public void AddPorposal(porposalDto porposaldto)
        {
            FreeLancer freeLancerobj = db.FreeLance.FirstOrDefault(f => f.ID == porposaldto.freeLancerObjId);
            job jobObjjj = db.job.FirstOrDefault(j => j.ID == porposaldto.JobObjId);
            proposal newPorposal = new proposal()
            {
                proposal_time = DateTime.Now,
                payment_amount = porposaldto.payment_amount,
                freelancer_comment = porposaldto.freelancer_comment,
                FreeLancerObj = freeLancerobj,
                JobObj = jobObjjj

            };
            db.proposal.Add(newPorposal);
            db.SaveChanges();
        }

        // DELETE: api/proposals/5
        [ResponseType(typeof(proposal))]
        public IHttpActionResult Deleteproposal(int id)
        {
            proposal proposal = db.proposal.Find(id);
            if (proposal == null)
            {
                return NotFound();
            }

            db.proposal.Remove(proposal);
            db.SaveChanges();

            return Ok(proposal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool proposalExists(int id)
        {
            return db.proposal.Count(e => e.id == id) > 0;
        }
    }
}