using System.ComponentModel.DataAnnotations;

namespace JLD.RiverLane.Models.Enums
{
    public enum PackageType
    {
        [Display(Name="Pre Wedding Photo Shoot")]
        PreWedding = 1,
        [Display(Name="Half Day Package")]
        HalfDay = 2,
        [Display(Name="Half Day and Additional Evening Package")]
        HalfDayAndEvening = 3,
        [Display(Name="Full Day Package")]
        FullDay = 4,
        [Display(Name="Full Day And Additional Evening Package")]
        FullDayAndEvening = 5,
        [Display(Name="Other (Describe below!)")]
        Other = 6
    }
}