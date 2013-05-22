using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ting.Models;
using System.Web.Http.Description;
using Ting.Common;
using log4net;
namespace Ting
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static ILog logger = log4net.LogManager.GetLogger(typeof(MvcApplication));

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterAuth();

            //初始化信息
            //Caution：在正式环境下请把此段删除！！！
            System.Data.Entity.Database.SetInitializer(new TingContextInitializer());

            //获取api方法的说明文档
            GlobalConfiguration.Configuration.Services.Replace(
    typeof(IDocumentationProvider), new DocProvider());

            //读取lognet配置
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                if (Server.GetLastError() is HttpException)
                {
                    var httpExp = Server.GetLastError() as HttpException;
                    if (httpExp != null)
                    {
                        if (httpExp.GetHttpCode() == 404)
                        {
                            return;
                        }
                    }
                }

                Exception objExp = Server.GetLastError();
                if (objExp != null)
                {
                    logger.Error(objExp);
                }
            }
            catch { }
        }
    }
}