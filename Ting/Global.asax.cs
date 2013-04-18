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

namespace Ting
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
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

        }
    }
}