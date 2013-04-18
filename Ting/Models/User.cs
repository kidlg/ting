using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ting.Models
{

    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 用户
    /// create by lg 2013-1-11
    /// </summary>
    public class User
    {
        
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [MaxLength(56)]
        public string Name { get; set; }
        [MaxLength(56)]
        public string Password { get; set; }
        [MaxLength(56)]
        public string NickName { get; set; }
        [MaxLength(100)]
        public string RegDevice { get; set; }

        public DateTime RegTime { get; set; }


        //public ICollection<Work> Works { get; set; }
    }
}