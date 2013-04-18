using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ting.Models
{
    public class CommonModelDTO<T>
    {
        public IEnumerable<T> List { get; set; }

        public int Count { get; set; }

        public int Page { get; set; }

        public CommonModelDTO(IEnumerable<T> list, int count,int pageSize,int pageIndex)
        {
            this.List = list;
            this.Page = pageIndex;
            this.Count = count / pageSize + (count % pageSize == 0 ? 0 : 1);
        }
    
    
    }
}