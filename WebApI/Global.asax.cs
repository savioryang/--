using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApI.handle;

namespace WebApI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitConfig();//加载配置文件
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void InitConfig()
        {
            try
            {
                SystemConfig.DbConnection = System.Configuration.ConfigurationManager.AppSettings["DbConnection"].ToString();
            }
            catch(Exception e)
            {
                
            }
        }
    }
}
