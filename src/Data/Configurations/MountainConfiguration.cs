using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Data.Configurations
{
    public class MountainConfiguration : EntityTypeConfiguration<Mountain>
    {
        public MountainConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasMaxLength(100).IsRequired();
            Property(x => x.Height.Metres).HasColumnName("HeightInMetres").IsRequired();

            Property(x => x.Location.Latitude).HasColumnName("Latitude").IsRequired();
            Property(x => x.Location.Longitude).HasColumnName("Longitude").IsRequired();
            Property(x => x.Location.GridReference.SixFigure).HasColumnName("SixFigureGridReference").HasMaxLength(8).IsRequired();
            Property(x => x.Location.GridReference.TenFigure).HasColumnName("TenFigureGridReference").HasMaxLength(12).IsOptional();

            HasRequired(x => x.Region).WithMany(x => x.Mountains);

            Property(x => x.Summit.Description).HasColumnName("SummitDescription").HasMaxLength(1000).IsOptional();
            Property(x => x.Summit.Notes).HasColumnName("SummitNotes").HasMaxLength(1000).IsOptional();

            Property(x => x.Prominence.Height.Metres).HasColumnName("ProminenceHeightInMetres").IsRequired();
            Property(x => x.Prominence.Above.SixFigureGridReference).HasColumnName("ProminenceAboveSixFigureGridReference").HasMaxLength(8).IsOptional();
            Property(x => x.Prominence.Above.TenFigureGridReference).HasColumnName("ProminenceAboveTenFigureGridReference").HasMaxLength(12).IsOptional();
            Property(x => x.Prominence.Above.Feature).HasColumnName("ProminenceAboveFeature").HasMaxLength(50).IsOptional();
            Property(x => x.Prominence.Above.Height.Metres).HasColumnName("ProminenceAboveHeightInMetres").IsRequired();

            HasMany(x => x.Countries).WithMany(x => x.Mountains).Map(x => x.ToTable("MountainCountries"));
            HasMany(x => x.Classifications).WithMany(x => x.Mountains).Map(x => x.ToTable("MountainClassifications"));
            HasMany(x => x.Maps).WithMany(x => x.Mountains).Map(x => x.ToTable("MountainMaps"));

            HasOptional(x => x.Parent).WithMany(x => x.Children);

            HasMany(x => x.Aliases);
        }
    }
}
