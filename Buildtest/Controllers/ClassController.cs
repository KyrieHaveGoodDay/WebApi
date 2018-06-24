using Buildtest.Models;
using Buildtest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Buildtest.Controllers
{
    public class ClassController : ApiController
    {
        [HttpGet]
        [Route("api/Build/InquireClass")]
        public IHttpActionResult InquireClass()
        {
            using (ClassService classService = new ClassService())
            {
                List<ClassModels> models = classService.Inquireclass();
                return Ok(models);
            }
        }
        
    

    }
}
