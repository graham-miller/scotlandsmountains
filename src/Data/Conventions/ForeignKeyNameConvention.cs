using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ScotlandsMountains.Data.Conventions
{
    public class ForeignKeyNameConvention : IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType association, DbModel model)
        {
            if (!association.IsForeignKey) return;

            var constraint = association.Constraint;
            if (DoPropertiesHaveDefaultNames(constraint.FromProperties, constraint.ToProperties))
                NormalizeForeignKeyProperties(constraint.FromProperties);

            if (DoPropertiesHaveDefaultNames(constraint.ToProperties, constraint.FromProperties))
                NormalizeForeignKeyProperties(constraint.ToProperties);
        }

        private static bool DoPropertiesHaveDefaultNames(IReadOnlyList<EdmProperty> properties, IReadOnlyList<EdmProperty> otherEndProperties)
        {
            if (properties.Count != otherEndProperties.Count) return false;

            for (var index = 0; index < properties.Count; ++index)
                if (!properties[index].Name.EndsWith("_" + otherEndProperties[index].Name)) return false;

            return true;
        }

        private static void NormalizeForeignKeyProperties(IReadOnlyList<EdmProperty> properties)
        {
            for (var index = 0; index < properties.Count; ++index)
            {
                var underscoreIndex = properties[index].Name.IndexOf('_');
                if (underscoreIndex > 0) properties[index].Name = properties[index].Name.Remove(underscoreIndex, 1);
            }
        }
    }
}