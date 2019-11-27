using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApI.handle;

namespace WebApI.Controllers
{
    public class TestController : ApiController
    {
        [HttpPost]
        [Route("api/home/getem")]
        public IHttpActionResult Getemdsda()
        {
            SqlSugarClient sql = datahandle.GetDataConnect();
            return Json("测试成功");            
        }

        [HttpPost]
        [Route("api/home/getom")]
        public IHttpActionResult Getom()
        {
            return Json("测试成功");
        }
    }
}
