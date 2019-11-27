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
    public class UserPassRecoveryController : ApiController
    {
        enum ReconveryEnum
        {
            Mailbox,
            ShortMessage,
        }

       /// <summary>
       /// 密码寻回
       /// </summary>
       /// <param name="obj">寻回资料</param>
       /// <returns></returns>
        [HttpPost]
        [Route("user/passrecovery")]
        public IHttpActionResult UserPassRecovery(dynamic obj)
        {
            JObject je = new JObject();
            JObject jo = new JObject();
            string getStr = string.Empty;
            je = (JObject)JsonConvert.DeserializeObject(obj.ToString());

            SqlSugarClient sql = datahandle.GetDataConnect();
            //校验客户账户是否存在
            List<user_login> list_user = sql.Queryable<user_login>().Where(t =>
               t.userName == je["userName"].ToString()).ToList();
            if (list_user.Count > 0)
            {
                user_login user_LoginModel = list_user.First();
                user_LoginModel.userPwd = Md5Control.MD5Encrypt(je["userPwd"].ToString());
                int  Result = sql.Updateable<user_login>(user_LoginModel).ExecuteCommand();
                if (Result == 1)
                {
                    jo.Add("Message", "修改完成");
                    jo.Add("Result", 1);
                }
                else
                {
                    jo.Add("Result", 0);
                    jo.Add("Message", "修改失败");
                }
            } 
            return Json(jo.ToString());

        }

          /// <summary>
          /// 获取密保问题
          /// </summary>
          /// <param name="obj"></param>
          /// <returns></returns>
        [HttpPost]
        [Route("user/passrecoveryList")]
        public IHttpActionResult GetUserPassRecoveryList(dynamic obj) {

            JObject je = new JObject();
            JObject jo = new JObject();

            try
            {
                string getStr = string.Empty;
                je = (JObject)JsonConvert.DeserializeObject(obj.ToString());
                SqlSugarClient sql = datahandle.GetDataConnect();
                //校验客户账户是否存在
                List<user_login> list_user = sql.Queryable<user_login>().Where(t =>
                   t.userName == je["userName"].ToString()).ToList();
                if (list_user.Count > 0)
                {
                    //获取密保问题
                    List<user_recovery> list_SecretProtection = sql.Queryable<user_recovery>().Where(
                        r => list_user.First().userID == r.userID
                        ).ToList(); 
                    jo.Add("Result", 1);
                    jo.Add("PassRecoveryCount", list_SecretProtection.Count);
                    jo.Add("PassRecoveryList", JsonConvert.SerializeObject(list_SecretProtection));

                }
                else
                {
                    jo.Add("Result", 2);
                    jo.Add("Message", "用户不存在，请先注册！");
                }
            }
            catch (Exception error)
            {
                jo.Add("Result", -1);
                jo.Add("Message", error.Message);
            }
            return Json(jo.ToString());
        }
    }
}
