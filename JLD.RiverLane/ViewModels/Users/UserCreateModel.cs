using FluentValidation.Attributes;

namespace JLD.RiverLane.ViewModels.Users
{
    [Validator(typeof(UserCreateModelValidator))]
    public class UserCreateModel
    {
        public string Username { get; set; }

        public PasswordModel PasswordDetails { get; set; }
    }
}