using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JLD.RiverLane.Infrastructure.Attributes
{
    public class FontAwesomeClassAttribute : Attribute
    {
        public FontAwesomeClassAttribute(string css)
        {
            CssClass = css;
        }

        public string CssClass { get; private set; }
    }
}