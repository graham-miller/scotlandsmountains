using FluentNHibernate.Mapping;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Data.Mappings
{
    public class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {
            Id(x => x.Id).Index("CountriesIndex");
            Map(x => x.Name);
            HasMany(x => x.Mountains).KeyColumn("CountryId");
        }
    }
}