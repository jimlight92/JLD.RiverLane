using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace JLD.RiverLane.DataAccess.Conventions
{
    public class ColumnNameConvention : UpperCaseSplitConvention
    {
        public ColumnNameConvention()
        {
            this.Properties().Configure(x => x.HasColumnName(GetUpperCaseSplit(x.ClrPropertyInfo.Name)));
        }
    }
}