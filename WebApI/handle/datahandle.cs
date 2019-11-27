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
        private  static SqlSugarClient _db=null;
        private  static void SqlConnect()
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
        //将静态变量改成单例
        private static readonly object data_lock = new object();
        public static SqlSugarClient GetDataConnect()
        {
            if (_db == null)
            {
                lock (data_lock)
                {
                    if (_db == null)
                    {
                        SqlConnect();
                    }
                }
            }
            return _db;
        }
    };

}