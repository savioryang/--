using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using Newtonsoft.Json;
using WebApI.handle;
using System.Text;
using SqlSugar;

namespace WebApI.Controllers.user
{
    public class UserRegisController : ApiController
    {
        [HttpPost]
        [Route("user/regis")]
        public IHttpActionResult GetRegisMsg(object obj)
        {
            lock (obj)
            {
                JObject je = new JObject();
                je = (JObject)JsonConvert.DeserializeObject(obj.ToString());
                user_login user = new user_login();
                user.userName = je["userName"].ToString();
                user.userPwd = Md5Control.MD5Encrypt(je["userPwd"].ToString());
                user.userID = datahandle.StringToHexString(user.userName + je["userPwd"].ToString(), Encoding.UTF8);
                user.id = Convert.ToInt32(je["id"].ToString());
                datahandle.SqlConnect();
                int Result = datahandle._db.Insertable(user).ExecuteCommand();
                JObject jo = new JObject();
                if (Result == 1)
                {
                    jo.Add("Message", "注册成功");
                }
                else
                    jo.Add("Message", "注册失败");
                jo.Add("Result", Result);
                return Json(jo.ToString());
            }
        }
    }
}
