using System;

namespace Ting.Models
{
    /// <summary>
    /// 描述Api参数的属性
    /// create by lg 2013-1-21
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiParameterDocAttribute : Attribute
    {
        public ApiParameterDocAttribute(string param, string doc)
        {
            Parameter = param;
            Documentation = doc;
        }
        public string Parameter { get; set; }
        public string Documentation { get; set; }
    }
}