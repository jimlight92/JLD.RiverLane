using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JLD.RiverLane.DataAccess.Conventions
{
    public class ForeignKeyConvention : UpperCaseSplitConvention, IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType association, DbModel model)
        {
            if (association.IsForeignKey)
            {
                ApplyConvention(association.Constraint.FromProperties);
                ApplyConvention(association.Constraint.ToProperties);
            }
        }

        private void ApplyConvention(ReadOnlyMetadataCollection<EdmProperty> properties)
        {
            foreach (var property in properties)
            {
                if (!string.Equals(property.Name, property.Name.ToUpperInvariant(), StringComparison.Ordinal))
                {
                    var newPropertyName = GetUpperCaseSplit(property.Name.Replace("_", ""));
                    property.Name = newPropertyName;
                }
            }
        }
    }
}
