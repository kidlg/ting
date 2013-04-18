using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Ting.Models;

namespace Ting.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    ViewBag.Message = "修改此模板以快速启动你的 ASP.NET MVC 应用程序。";

        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "你的应用程序说明页。";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "你的联系方式页。";

        //    return View();
        //}
        /// <summary>
        /// 帮助页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Help()
        {

             
            var explorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();
            return View(new ApiModel(explorer));
        }

        public ActionResult Test()
        {

            return View();
        }
    }
}
