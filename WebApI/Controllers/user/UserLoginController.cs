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
                datahandle.SqlConnect();
                List<user_login> list_user = datahandle._db.Queryable<user_login>().Where(t =>
               t.userName == je["userName"].ToString()).ToList();
                if (list_user.Count ==1)
                {
                    foreach (user_login user_Login in list_user)
                    {
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
            return Json(jo.ToString());
        }
    }
}
