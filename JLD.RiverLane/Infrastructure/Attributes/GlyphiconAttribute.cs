using JLD.RiverLane.Models;
using System;
using BaseClasses.Fixtures;
using BaseClasses.Helpers;

namespace JLD.RiverLane.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class GlyphiconAttribute : Attribute
    {
        /// <summary>
        /// Creates a new glyphicon Attribute with the specified glyphicon
        /// </summary>
        /// <param name="glyphicon"></param>
        public GlyphiconAttribute(string glyphicon)
        {
            Check.NotNullOrEmpty(glyphicon, nameof(glyphicon));
            Glyphicon = glyphicon;
        }

        public string Glyphicon { get; private set; }
    }
}