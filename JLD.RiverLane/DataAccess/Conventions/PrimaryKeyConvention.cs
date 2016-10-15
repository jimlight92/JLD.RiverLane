using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace JLD.RiverLane.DataAccess.Conventions
{
    public class PrimaryKeyConvention : UpperCaseSplitConvention
    {
        public PrimaryKeyConvention()
        {
            this.Properties().Where(x => x.Name == "Id").Configure(x => x.HasColumnName(GetUpperCaseSplit(x.ClrPropertyInfo.ReflectedType.Name) + "_ID"));
        }
    }
}