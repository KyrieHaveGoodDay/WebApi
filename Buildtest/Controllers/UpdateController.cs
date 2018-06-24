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
    public class UpdateController : ApiController
    {
        [HttpPost]
        [Route("api/Build/Update")]
        public IHttpActionResult Update([FromBody] BuildModels models)
        {
            using (UpdateService up = new UpdateService())
            {
                int date = up.Updata( models.Build_Class, models.Build_Money , models.Build_ID);
                return Ok(date);
            }
                
        }
    }
}
