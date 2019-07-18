using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GraduatedProject.Controllers
{
    public class ImageUploadController : ApiController
    {
        [HttpPost]
        [Route("api/ImageUpload")]
        public IHttpActionResult UploadImage()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;

            // Upload Image
            var postedFile = httpRequest.Files["Image"];
            // Create custem filename
            imageName =
                new string(Path.GetFileNameWithoutExtension(postedFile.FileName).ToArray());
            imageName = imageName + Path.GetExtension((postedFile.FileName));
            var filePath = HttpContext.Current.Server.MapPath("~/Content/Image/" + imageName);
            postedFile.SaveAs(filePath);
            return Ok();
        }
    }
}
