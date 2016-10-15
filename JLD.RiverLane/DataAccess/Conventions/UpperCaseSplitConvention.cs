using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace JLD.RiverLane.DataAccess.Conventions
{
    public abstract class UpperCaseSplitConvention : Convention
    {
        public string GetUpperCaseSplit(string name)
        {
            var result = Regex.Replace(name, ".[A-Z]", m => m.Value[0] + "_" + m.Value[1]);
            return result.ToUpper();
        }
    }
}