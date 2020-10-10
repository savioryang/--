using SqlSugar;
using System;
using System.IO;
using System.Text;

namespace Casting.Common
{
    public class BaseDBConfig
    {

        public static string ConnectionString { get; set; }
        public static DbType DbType { get; set; } = DbType.MySql;



        /// <summary>
        /// 插入一条日志
        /// </summary>
        /// <param name="content"></param>
        public static void AddToLog(string content)
        {
            string logName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            createFile(content, logName);
        }


        public static void createFile(string contents, string fName)
        {

            try
            {
                string rootDir = AppDomain.CurrentDomain.BaseDirectory;
                string fNameBak = rootDir + "/bak/logs/" + fName + "." + DateTime.Now.ToString("yyyyMMddHHmmss");
                fName = rootDir + "/logs/" + fName;

                if (!Directory.Exists(rootDir + "/logs/"))
                    Directory.CreateDirectory(rootDir + "/logs/");

                if (!Directory.Exists(rootDir + "/bak/logs/"))
                    Directory.CreateDirectory(rootDir + "/bak/logs/");
                if (!File.Exists(fName))
                {
                }
                else
                {
                    FileInfo fi = new FileInfo(fName);
                    if (fi.Length / 1024 >= 8192)
                    {
                        File.Move(fName, fNameBak);
                        FileStream fsClear = new FileStream(fName, FileMode.Create);
                        StreamWriter writeClear = new StreamWriter(fsClear);
                        writeClear.Write("");
                        writeClear.Flush();
                        writeClear.Close();
                        fsClear.Flush(true);
                        fsClear.Close();
                    }
                }
                FileStream fileStream = new FileStream(fName, FileMode.Append);
                StringBuilder sb = new StringBuilder();
                StreamWriter write = new StreamWriter(fileStream);
                try
                {
                    sb.Append("----------------------------" + DateTime.Now + "----------------------------" + "\r\n" + contents);
                }
                catch (Exception e)
                {
                    sb.Append(e);
                }
                write.WriteLine(sb.ToString());
                write.Flush();
                fileStream.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }


        }


      
    }
}
