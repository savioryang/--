using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    }
}
