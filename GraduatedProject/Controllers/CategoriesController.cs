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
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Categories
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }
        //-------------start Ramey------------------
        public IHttpActionResult GetCategoryById(int id)
        {
            var catById = db.Categories.Find(id);
            if (catById != null)
            {
                return Ok(catById);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, $"This id: {id} not Founded");
            }
        }

        [HttpPost]

        public IHttpActionResult PostCategory([FromBody] Category cat)
        {


            try
            {
                Category category = new Category()
                {
                    CatName = cat.CatName,
                    ImageName = cat.ImageName
                };
                db.Categories.Add(category);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception )
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            try
            {
                var delCat = db.Categories.FirstOrDefault(c => c.ID == id);
                if (delCat.ID != 0)
                {
                    db.Categories.Remove(delCat);
                    db.SaveChanges();
                    return Ok("success");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
 
        public IHttpActionResult PutUpdateCategory(int id, [FromBody]Category category)
        {
            try
            {
                var updateCat = db.Categories.Where(c => c.ID == id).Select(c => c).FirstOrDefault();
                if (updateCat != null)
                {
                    updateCat.CatName = category.CatName;
                    updateCat.ImageName = category.ImageName;

                    db.SaveChanges();
                    return Ok("Category Updated");
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //----------------end Ramey----------------
        [Route("JobsWithCatId/{id}")]
        public List<job> GetJobsWithCatId(int id)
        {
            List<job> jobList = db.job.Where(i => i.CategoryObj.ID == id).ToList();
            return jobList;
        }

        //// GET: api/Categories/5
        //[ResponseType(typeof(Category))]
        //public IHttpActionResult GetCategory(int id)
        //{
        //    Category category = db.Categories.Find(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(category);
        //}

        //// PUT: api/Categories/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCategory(int id, Category category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != category.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Categories
        //[ResponseType(typeof(Category))]
        //public IHttpActionResult PostCategory(Category category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Categories.Add(category);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = category.ID }, category);
        //}

        //// DELETE: api/Categories/5
        //[ResponseType(typeof(Category))]
        //public IHttpActionResult DeleteCategory(int id)
        //{
        //    Category category = db.Categories.Find(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Categories.Remove(category);
        //    db.SaveChanges();

        //    return Ok(category);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.ID == id) > 0;
        }
    }
}