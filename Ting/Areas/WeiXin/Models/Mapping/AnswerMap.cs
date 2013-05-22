using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ting.Areas.WeiXin.Models.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Content)
                .IsRequired()
                .HasMaxLength(200);


            // Table & Column Mappings
            this.ToTable("Answer");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.QID).HasColumnName("QID");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.UserOpenId).HasColumnName("UserOpenId");
        }
    }
}