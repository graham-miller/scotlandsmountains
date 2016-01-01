using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Humanizer;

namespace ScotlandsMountains.Data.Conventions
{
    public class PluralizeTableNamesConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.EntityType.Name.Pluralize());
        }
    }
}