using System.Web.Mvc;

namespace Ting.Areas.WeiXin
{
    public class WeiXinAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WeiXin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "WeiXin_default",
                "WeiXin/{controller}/{action}/{id}",
                new { controller="Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
