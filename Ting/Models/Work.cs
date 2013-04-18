using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ting.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 作品
    /// create by lg 2013-1-11
    /// </summary>
    public class Work
    {

        public int Id { get; set; }
        [MaxLength(56)]
        public string Name { get; set; }

        public int AnnouncerId { get; set; }
        [MaxLength(24)]
        public string AnnoucerName { get; set; }
        [MaxLength(24)]
        public string Author { get; set; }

        public int SectionSum  { get; set; }
        [MaxLength(1000)]
        public string Breif { get; set; }

        public int CateId { get; set; }
        [MaxLength(100)]
        public string Cover { get; set; }

        public int Status { get; set; }

        public int Sort { get; set; }

        public int Hot { get; set; }

        public int CommentSum { get; set; }

        public int CommentLv { get; set; }

        public DateTime CreateTime { get; set; }


        //navigation properties
        //public ICollection<Section> SectionList { get; set; }

        //public ICollection<Comment> CommentList { get; set; }

    }
}