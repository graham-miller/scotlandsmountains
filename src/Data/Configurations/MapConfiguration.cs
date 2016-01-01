using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Domain.Entities.Maps;

namespace ScotlandsMountains.Data.Configurations
{
    public class MapConfiguration : EntityTypeConfiguration<Map>
    {
        public MapConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Code).HasMaxLength(10).IsRequired();
            Property(x => x.Name).HasMaxLength(250).IsRequired();
            Property(x => x.Isbn).HasMaxLength(100).IsRequired();

            const string discriminatorColumnName = "MapPublisherAndSeries";
            Map<OsExplorerMap>(x => x.Requires(discriminatorColumnName).HasValue("OS Explorer"));
            Map<OsExplorerActiveMap>(x => x.Requires(discriminatorColumnName).HasValue("OS Explorer Active"));
            Map<OsLandrangerMap>(x => x.Requires(discriminatorColumnName).HasValue("OS Landranger"));
            Map<OsLandrangerActiveMap>(x => x.Requires(discriminatorColumnName).HasValue("OS Landranger Active"));
            Map<OsDiscoveryMap>(x => x.Requires(discriminatorColumnName).HasValue("OS Discovery"));

            HasMany(x => x.Mountains).WithMany(x => x.Maps).Map(x => x.ToTable("MountainMaps"));
        }
    }
}
