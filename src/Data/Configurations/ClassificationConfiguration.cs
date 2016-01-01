using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Data.Configurations
{
    public class ClassificationConfiguration : EntityTypeConfiguration<Classification>
    {
        public ClassificationConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasMaxLength(100).IsRequired();

            HasMany(x => x.Mountains).WithMany(x => x.Classifications).Map(x => x.ToTable("MountainClassifications"));
        }
    }
}
