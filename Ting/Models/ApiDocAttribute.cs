using System;

namespace Ting.Models
{
    /// <summary>
    /// 描述Api作用的属性
    /// create by lg 2013-1-21
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiDocAttribute : Attribute
    {
        public ApiDocAttribute(string doc)
        {
            Documentation = doc;
        }
        public string Documentation { get; set; }
    }

}