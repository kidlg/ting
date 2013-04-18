using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;
namespace Ting.Common
{
    public class PagingProvider
    {
        public List<T> GetPagingList<T>(string orderBy, bool ascending, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            return null;
        }
    }
}