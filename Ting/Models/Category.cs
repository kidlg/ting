using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ting.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 分类
    /// create by lg 2013-1-11
    /// </summary>
    public class Category
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [MaxLength(56)]
        public string Name { get; set; }

        public int  Sum{ get; set; }

        public int Hot { get; set; }

        public int Sort { get; set; }

        public int Status { get; set; }

        public int ParentCateId { get; set; }


        public DateTime CreateTime { get; set; }

        //Navigation property
        //public  ICollection<Category> SubCategories { get; set; }

        //public  ICollection<Work> WorkList { get; set; }

    }
}