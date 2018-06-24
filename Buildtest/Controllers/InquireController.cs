using Buildtest.Inquire;
using Buildtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Buildtest.Controllers
{
    public class InquireController : ApiController
    {
        [HttpGet]
        [Route("api/Build/Inquire")]
        public IHttpActionResult Inquire(int Build_ID)
        {
            using (InquireService inquireservice = new InquireService())
            {
                List<BuildModels> buildModels = inquireservice.Inquire(Build_ID);
                return Ok(buildModels);
            }
                
        }
    }
}
