using JLD.RiverLane.Infrastructure.Attributes;
using System.ComponentModel;

namespace JLD.RiverLane.Models.Enums
{
    public enum AlertType
    {
        [Description("success")]
        [Glyphicon("ok-circle")]
        Success,
        [Description("info")]
        [Glyphicon("exclamation-sign")]
        Info,
        [Description("warning")]
        [Glyphicon("warning-sign")]
        Warning,
        [Description("danger")]
        [Glyphicon("remove-circle")]
        Error
    }
}