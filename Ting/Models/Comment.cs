using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ting.Models
{
    using System.ComponentModel.DataAnnotations;


    /// <summary>
    /// 评论
    /// create by lg 2013-1-11
    /// </summary>
    public class Comment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int WorkId { get; set; }
        [MaxLength(56)]
        public string NickName { get; set; }

        public int Level { get; set; }
        [MaxLength(500)]
        public string Content { get; set; }

        public int Status { get; set; }

        public DateTime CreateTime { get; set; }


        //navigation properties
        //public Work work { get; set; }


    }
}