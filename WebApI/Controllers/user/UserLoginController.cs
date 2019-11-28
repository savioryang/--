using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApI.handle;
using LogR;
using log4net.Repository.Hierarchy;

namespace WebApI.Controllers.user
{
    public class UserLoginController : ApiController
    {
        [HttpPost]
        [Route("user/login")]
        public IHttpActionResult UserLogin(dynamic obj)
        {
           
           JObject je = new JObject();
            JObject jo = new JObject();
            try
            {
                je = (JObject)JsonConvert.DeserializeObject(obj.ToString());
                LoggerHelp.LogInfo("UserLogin接收数据："+ Md5Control.MD5Encrypt(je.ToString()));
                SqlSugarClient sql = datahandle.GetDataConnect();
                List<user_login> list_user = sql.Queryable<user_login>().Where(t =>
                t.userName == je["userName"].ToString()).ToList();
                if (list_user.Count == 1)
                {
                    user_login user_Login = list_user[0];
                    if (user_Login.userPwd == Md5Control.MD5Encrypt(je["userPwd"].ToString()))
                    {
                        jo.Add("Result", 1);
                        jo.Add("Message", "登录成功");
                    }
                    else
                    {
                        jo.Add("Result", 0);
                        jo.Add("Message", "登录失败，密码错误");
                    }

                }
                else
                {
                    jo.Add("Result", 2);
                    jo.Add("Message", "用户不存在，请先注册！");
                }
            }
            catch(Exception error)
            {
                jo.Add("Result", -1);
                jo.Add("Message", error.Message);
            }
            LoggerHelp.LogInfo("UserLogin返回数据：" + jo);
            return Json(jo.ToString());
        }
    }
}
