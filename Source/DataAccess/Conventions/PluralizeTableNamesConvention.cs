using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ScotlandsMountains.DataAccess.Conventions
{
    public class PluralizeTableNamesConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.EntityType.Name + "s");
        }
    }
}
