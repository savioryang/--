using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApI.handle;
using System.Web.Script.Serialization;

namespace WebApI.Controllers.talk
{
    public class TalkInsertController : ApiController
    {
        [HttpPost]
        [Route("Talk/Insert")]
        public IHttpActionResult TalkInsert(dynamic obj)
        {
            JObject je = new JObject();
            JObject jo = new JObject();
            try
            {
                je = (JObject)JsonConvert.DeserializeObject(obj.ToString());
                datahandle.SqlConnect();
                JavaScriptSerializer JavaScriptSerializer1 = new JavaScriptSerializer();
                board_all_systerm result = JavaScriptSerializer1.Deserialize<board_all_systerm>(obj.ToString());
            }
            catch(Exception error)
            {
                jo.Add("Message", error.Message);
            }
            return Json(jo.ToString());
;        }
    }
}
