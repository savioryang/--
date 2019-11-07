using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApI.handle
{
    public class datahandle
    {
        public static string StringToHexString(string s, Encoding encode)
        {
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符
            {
                result += Convert.ToString(b[i], 16);
            }
            return result;
        }
        public  static SqlSugarClient _db;

        public static void SqlConnect()
        {
            try
            {
                _db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = SystemConfig.DbConnection,
                    DbType = SqlSugar.DbType.MySql,//设置数据库类型        
                    IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放       
                    InitKeyType = InitKeyType.Attribute //从实体特性中读取主键自增列信息   
                });
            }
            catch (Exception ea)
            {

            }
        }
    }
}