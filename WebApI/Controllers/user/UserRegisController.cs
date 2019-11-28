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
using System.IO;
using System.Web;

namespace WebApI.Controllers.user
{
    public class UserRegisController : ApiController
    {
        [HttpPost]
        [Route("user/regis")]
        public IHttpActionResult GetRegisMsg(object obj)
        {
            JObject je = new JObject();
            JObject jo = new JObject();
            try
            {
                string getStr = string.Empty;
                je = (JObject)JsonConvert.DeserializeObject(obj.ToString());
                LoggerHelp.LogInfo("GetRegisMsg接收数据：" + je);
                //判断一下用户名是否存在是否被注册过
                SqlSugarClient sql = datahandle.GetDataConnect();
                List<user_login> list_user = sql.Queryable<user_login>().Where(t =>
                t.userName == je["userName"].ToString()).ToList();
                if (list_user.Count > 0)
                {
                    jo.Add("Result", 3);
                    jo.Add("Message", "用户名已存在");
                }
                else
                {
                    user_login user = new user_login();
                    user.userName = je["userName"].ToString();
                    user.userPwd = Md5Control.MD5Encrypt(je["userPwd"].ToString());
                    user.userID = dataTransfer.StringToHexString(user.userName + je["userPwd"].ToString(), Encoding.UTF8);
                    //user.id = Convert.ToInt32(je["id"].ToString());
                    int Result = sql.Insertable(user).ExecuteCommand();
                    if (Result == 1)
                    {
                        jo.Add("Message", "注册成功");
                        jo.Add("Result", 1);
                    }
                    else
                    {
                        jo.Add("Result", 0);
                        jo.Add("Message", "注册失败");
                    }
                }
            }
            catch(Exception error)
            {
                jo.Add("Result", 4);
                jo.Add("Message", error.Message);
            }
            LoggerHelp.LogInfo("GetRegisMsg返回数据：" + jo);
            return Json(jo.ToString());
        }
    }
}
