using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebApI.handle
{
    public class SmtpHandle
    {
        public static string SendMsg(string user)
        {
            //实例化一个发送邮件类。
            MailMessage mailMessage = new MailMessage();
            //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
            mailMessage.From = new MailAddress("826569867@qq.com");
            //收件人邮箱地址。
            //mailMessage.To.Add(new MailAddress("1424503386@qq.com"));
            //邮件标题。
            mailMessage.Subject = "这是您的验证码，请在规定的时间正确填写！";
            //邮件内容。
            string code = GuidCode();
            mailMessage.Body = "您的验证码是:"+ code;
            mailMessage.To.Add(user);
            mailMessage.Priority = MailPriority.High;
            //实例化一个SmtpClient类。
            SmtpClient client = new SmtpClient();
            //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
            client.Host = "smtp.qq.com";
            //使用安全加密连接。
            client.EnableSsl = true;
            //不和请求一块发送。
            client.UseDefaultCredentials = false;
            //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
            client.Credentials = new NetworkCredential("826569867@qq.com", "sjniyzkrnogibbcg");
            //发送
            client.Send(mailMessage);
            return code;
        }
        private  static readonly string[] Zm = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                        "N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
        private  static readonly string[] Num = {"0","1","2","3","4","5","6","7","8","9" };
        private static string GuidCode()
        {
            Random r1 = new Random();
            string str = string.Empty;
            for(int i= 0; i <3; i++)
            {
                str += Zm[r1.Next(0, 26)];
            }
            for (int j = 0; j < 3; j++)
            {
                str += Num[r1.Next(0, 10)];
            }
            return str;
        }
    }
}