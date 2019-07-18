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
    public class test_resultController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/test_result
        public IQueryable<test_result> Gettest_result()
        {
            return db.test_result;
        }

        // GET: api/test_result/5
        [ResponseType(typeof(test_result))]
        public IHttpActionResult Gettest_result(int id)
        {
            test_result test_result = db.test_result.Find(id);
            if (test_result == null)
            {
                return NotFound();
            }

            return Ok(test_result);
        }

        // PUT: api/test_result/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttest_result(int id, test_result test_result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test_result.id)
            {
                return BadRequest();
            }

            db.Entry(test_result).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!test_resultExists(id))
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

        // POST: api/test_result
        [ResponseType(typeof(test_result))]
        //public IHttpActionResult Posttest_result(test_result test_result)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.test_result.Add(test_result);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = test_result.id }, test_result);
        //}

        [Route("AddTestResult")]
        public void AddTestResult(TestResultDto TestResultDtoObj)
        {
            FreeLancer FLancObj = db.FreeLance.FirstOrDefault(f => f.ID == TestResultDtoObj.FreeLancerObjId);
            test tObj = db.test.FirstOrDefault(t => t.id == TestResultDtoObj.testObjId);
            test_result TestResultObj = new test_result()
            {
                Test_time = DateTime.Now,
                test_Name = TestResultDtoObj.test_Name,
                score =TestResultDtoObj.score,
                FreeLancerObj = FLancObj,
                testObj = tObj
            };
            db.test_result.Add(TestResultObj);
            db.SaveChanges();

        }

        // DELETE: api/test_result/5
        [ResponseType(typeof(test_result))]
        public IHttpActionResult Deletetest_result(int id)
        {
            test_result test_result = db.test_result.Find(id);
            if (test_result == null)
            {
                return NotFound();
            }

            db.test_result.Remove(test_result);
            db.SaveChanges();

            return Ok(test_result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool test_resultExists(int id)
        {
            return db.test_result.Count(e => e.id == id) > 0;
        }
    }
}