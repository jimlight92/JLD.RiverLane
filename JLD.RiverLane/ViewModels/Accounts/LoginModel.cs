using System.ComponentModel.DataAnnotations;

namespace JLD.RiverLane.ViewModels.Accounts
{
    public class LoginModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}