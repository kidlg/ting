using System.Web.Http.Description;
using Ting.Models;
using System.Linq;

namespace Ting.Common
{
    /// <summary>
    /// 获取Api描述信息
    /// create by lg 2013-1-21
    /// </summary>
    public class DocProvider : IDocumentationProvider
    {

        public string GetDocumentation(System.Web.Http.Controllers.HttpParameterDescriptor parameterDescriptor)
        {
            string doc = "";
            var attr = parameterDescriptor.ActionDescriptor
                   .GetCustomAttributes<ApiParameterDocAttribute>()
                   .Where(p => p.Parameter == parameterDescriptor.ParameterName)
                   .FirstOrDefault();
            if (attr != null)
            {
                doc = attr.Documentation;
            }
            return doc;

        }

        public string GetDocumentation(System.Web.Http.Controllers.HttpActionDescriptor actionDescriptor)
        {
            string doc = "";
            var attr = actionDescriptor.GetCustomAttributes<ApiDocAttribute>().FirstOrDefault();
            if (attr != null)
            {
                doc = attr.Documentation;
            }
            return doc;
        }
    }
}