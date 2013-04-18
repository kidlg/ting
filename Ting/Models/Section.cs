using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ting.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 剧集
    /// create by lg 2013-1-11
    /// </summary>
    public class Section
    {

        public int Id { get; set; }
        [MaxLength(56)]
        public string Name { get; set; }

        public int WorkId { get; set; }
        [MaxLength(1000)]
        public string Content { get; set; }

        public int Status { get; set; }

        public int Sort { get; set; }

        public bool IsUpdate { get; set; }

        public int UpdateId { get; set; }
        [MaxLength(56)]
        public string SectionsTime { get; set; }

        public DateTime CreateTime { get; set; }

        public int UserId { get; set; }




        //navigation properties
        //public Work work { get; set; }




    }
}