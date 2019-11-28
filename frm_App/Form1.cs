using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogR;
using SqlSugar;

namespace frm_App
{
    public partial class Form1 : Form
    {
        private SqlSugarClient _db;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnect();
            try
            {
                _db.DbFirst.IsCreateDefaultValue().
                    CreateClassFile("D:\\WorkTask\\代码\\talkManageControl\\frm_App\\bin\\Debug\\Model", "Model");
               
            }
            catch (Exception ex)
            {
               
            }
        }
        private void SqlConnect()
        {
            try
            {
                _db = new SqlSugarClient(new ConnectionConfig()
                {
                    //ConnectionString = "server=127.0.0.1;uid=dzwl;pwd=dzwl123456;database=savior_wy",
                    ConnectionString = "server=127.0.0.1;uid=dzwl;pwd=dzwl123456;database=tt_talk;port=3306;Allow User Variables=True;Old Guids=true",
                    DbType = SqlSugar.DbType.MySql,//设置数据库类型        
                    IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放       
                    InitKeyType = InitKeyType.Attribute //从实体特性中读取主键自增列信息   
                });
              
                // SqlConnect();
               
            }
            catch (Exception ea)
            {
              
            }
        }

        CookieContainer cookie = new CookieContainer();
        public string HttpWebPost(string Url, string postDataStr)
        {
            string retString = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                byte[] byteArray = Encoding.UTF8.GetBytes(postDataStr);
                request.Method = "POST";
                request.Timeout = 100000;
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = byteArray.Length;
                request.CookieContainer = cookie;
                //打开request字符流
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();


                HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();

                    //获取相应的状态代码
                    Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                    //定义response字符流
                    dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    retString = reader.ReadToEnd();//读取所有
                    Console.WriteLine(retString);
                    reader.Close();
                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                    //LogR.Logger.Error(ex, "request.GetResponse");
                    //throw ex;
                }
            }
            catch (Exception ex)
            {
                //LogR.Logger.Error(ex, "HttpPost");
                throw ex;
            }
            return retString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Text = HttpWebPost(textBox1.Text.Trim(),richTextBox1.Text.Trim().ToString());
            }
            catch(Exception error)
            {
                richTextBox2.Text = error.Message;
            }
        }
    }
}
