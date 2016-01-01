using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Data.Configurations
{
    public class AliasConfiguration : EntityTypeConfiguration<Alias>
    {
        public AliasConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}
