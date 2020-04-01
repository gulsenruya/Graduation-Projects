using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bespoke.Api.Controllers
{
    [RoutePrefix("api/branch")]
    public class BranchController : ApiController
    {
        [HttpGet]
        [Route]
        public IHttpActionResult GetBranchs()
        {
            var tmp = new
            {
                result = new
                {
                    service_status = "OK"
                }
            };
            return Ok(tmp);
        }
    }
}

