using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace talkManageControl.Controllers.userHandle
{
    public class userQueryController : ApiController
    {
        [HttpPost]
        [Route("api/home/userLogin")]
        public IHttpActionResult Getemdsda()
        {
            return Json("测试成功");
        }
    }
}
