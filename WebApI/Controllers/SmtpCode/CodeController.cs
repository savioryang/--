using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WebApI.handle;

namespace WebApI.Controllers.SmtpCode
{
    public class CodeController : ApiController
    {
        [HttpPost]
        [Route("query/code")]
        public IHttpActionResult QueryCode(dynamic obj)
        {
            JObject je = new JObject();
            JObject jo = new JObject();
            try
            {
                je = (JObject)JsonConvert.DeserializeObject(obj.ToString());
                Regex regEmail = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
                string userMail= je["QQMail"].ToString();
                if (!string.IsNullOrEmpty(userMail))
                {
                    if (regEmail.IsMatch(je["QQMail"].ToString()))  //验证邮箱格式是否正确
                    {
                        jo.Add("Code", SmtpHandle.SendMsg(userMail));
                        jo.Add("Result", 1);
                        jo.Add("Message", "验证码发送成功");
                    }
                    else
                    {
                        jo.Add("Result", 2);
                        jo.Add("Message", "邮箱格式错误");
                    }
                }
                else
                {
                    jo.Add("Result", 0);
                    jo.Add("Message", "邮箱为空");
                }
            }
            catch(Exception e)
            {
                jo.Add("Result", -1);
                jo.Add("Message", e.Message);
            }
            return Json(jo.ToString());
        }
    }
}
