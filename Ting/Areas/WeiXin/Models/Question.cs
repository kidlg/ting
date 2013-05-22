using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ting.Areas.WeiXin.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public Nullable<int> status { get; set; }
        public DateTime CreateTime { get; set; }
        public string UserOpenId { get; set; }
    }
}