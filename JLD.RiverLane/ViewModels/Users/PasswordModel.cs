using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace JLD.RiverLane.ViewModels.Users
{
    [Validator(typeof(PasswordModelValidator))]
    public class PasswordModel
    {        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}