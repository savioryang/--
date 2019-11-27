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
using SqlSugar;

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
                SqlSugarClient sql = datahandle.GetDataConnect();
                JavaScriptSerializer JavaScriptSerializer1 = new JavaScriptSerializer();
                board_all_systerm board_all_systerm_list = JavaScriptSerializer1.Deserialize<board_all_systerm>(obj.ToString());
                int count= sql.Insertable(board_all_systerm_list).ExecuteCommand();
                if (count == 1)
                {
                    jo.Add("Result", 1);
                    jo.Add("Message", "操作成功");
                }
                else
                {
                    jo.Add("Result", 0);
                    jo.Add("Message", "操作失败");
                }
            }
            catch(Exception error)
            {
                jo.Add("Result", -1);
                jo.Add("Message", error.Message);
            }
            return Json(jo.ToString());
;        }
    }
}
