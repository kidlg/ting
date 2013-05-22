using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Ting.Areas.WeiXin.Models.Mapping;

namespace Ting.Areas.WeiXin.Models
{
    public partial class WeixinRobotContext : DbContext
    {
        static WeixinRobotContext()
        {
            Database.SetInitializer<WeixinRobotContext>(null);
        }

        public WeixinRobotContext()
            : base("Name=WeixinRobotContext")
        {
        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new AnswerMap());
        }
    }
}
