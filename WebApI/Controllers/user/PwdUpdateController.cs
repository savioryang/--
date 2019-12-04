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

namespace WebApI.Controllers.user
{
    public class PwdUpdateController : ApiController
    {
        [HttpPost]
        [Route("user/PwdUpdate")]
        public IHttpActionResult PwdUpdate(dynamic obj)
        {
            JObject je = new JObject();
            JObject jo = new JObject();
            try
            {
                je = (JObject)JsonConvert.DeserializeObject(obj.ToString());
                LoggerHelp.LogInfo("PwdUpdate接收数据：" + je);
                SqlSugarClient sql = datahandle.GetDataConnect();
                List<user_login> user_Logins = sql.Queryable<user_login>().Where(t => 
                                   t.userName == je["userName"].ToString()).ToList();
                if (user_Logins.Count == 1)
                {
                    user_login user_Login = user_Logins[0];
                    if (user_Login.userPwd== Md5Control.MD5Encrypt(je["userPwdOld"].ToString()))
                    {
                        user_Login.userPwd = Md5Control.MD5Encrypt(je["userPwdNew"].ToString());
                        int Result = sql.Updateable(user_Login).ExecuteCommand();
                        if (Result==1)
                        {
                            jo.Add("Result", 1);
                            jo.Add("Message", "密码更换成功");
                        }
                        else
                        {
                            jo.Add("Result", 0);
                            jo.Add("Message", "密码更换失败");
                        }
                    }
                    else
                    {
                        jo.Add("Result", 0);
                        jo.Add("Message", "原密码错误");
                    }
                }
                else
                {
                    jo.Add("Result", 0);
                    jo.Add("Message", "用户名不存在");
                }

            }
            catch(Exception error)
            {
                jo.Add("Result", 3);
                jo.Add("Message", error.Message);
            }
            LoggerHelp.LogInfo("PwdUpdate返回数据：" + jo);
            return Json(jo.ToString());
        }
    }
}
