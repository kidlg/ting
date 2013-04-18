using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace Ting.Models
{
    public class ApiModel
    {
        IApiExplorer _explorer;
        public ApiModel(IApiExplorer explorer)
        {
            if (explorer==null)
            {
                throw new ArgumentException("explorer");
            }
            _explorer = explorer;
        }

        public ILookup<string, ApiDescription> GetApis()
        {
            return _explorer.ApiDescriptions.ToLookup(api => api.ActionDescriptor.ControllerDescriptor.ControllerName);
        }
    }
}