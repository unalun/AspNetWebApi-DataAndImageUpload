using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SampleWebApiDataAndImageUpload.Controllers
{
    public class ContactController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.Created);

            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/images/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }

                var Name = httpRequest["Name"].ToString();
                var SurName = httpRequest["SurName"].ToString();
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;

        }
    }

    public class ContactVm
    {
        public int Name { get; set; }
        public string SurName { get; set; }
    }

}
