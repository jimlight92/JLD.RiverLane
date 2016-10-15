using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebGrease.Css.Extensions;

namespace JLD.RiverLane.DataAccess.Conventions
{
    public class ForeignKeyConvention : UpperCaseSplitConvention, IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType association, DbModel model)
        {
            if (association.IsForeignKey)
            {
                MakeCaseRecordRequiredInNavigationProperties(association);
                ApplyConvention(association.Constraint.FromProperties);
                ApplyConvention(association.Constraint.ToProperties);
            }
        }

        private static void MakeCaseRecordRequiredInNavigationProperties(AssociationType association)
        {
            if (association.Constraint.FromRole.Name == "CaseRecord" && !(association.Constraint.ToRole.Name == "Body"))
            {
                if (association.Constraint.FromRole.RelationshipMultiplicity == RelationshipMultiplicity.One)
                {
                    association.Constraint.FromRole.DeleteBehavior = OperationAction.Cascade;
                    association.Constraint.ToProperties.ForEach(x => x.Nullable = false);
                };
            };
        }

        private void ApplyConvention(ReadOnlyMetadataCollection<EdmProperty> properties)
        {
            foreach (var property in properties)
            {
                if (!string.Equals(property.Name, property.Name.ToUpperInvariant(), StringComparison.Ordinal))
                {
                    var newPropertyName = GetUpperCaseSplit(property.Name);
                    property.Name = newPropertyName;
                }
            }
        }
    }
}
