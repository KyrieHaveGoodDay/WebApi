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
    public class InsertClassController : ApiController
    {
        [HttpPost]
        [Route("api/Build/InsertClass")]
        public IHttpActionResult InsertClass([FromBody] BuildModels models)
        {
            using (ClassService insert = new ClassService())
            {
                int insertclass = insert.Insertclass(models.Class_name);
                return Ok(insertclass);
            }
                
        }
    }
}
