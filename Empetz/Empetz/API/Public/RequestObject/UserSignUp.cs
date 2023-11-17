using System.ComponentModel.DataAnnotations;

namespace Empetz.API.Public.RequestObject
{
    public class UserSignUp
    {
        public UserSignUp()
        {
        }

        public UserSignUp(string FirstName, string Phone)
        {
            FirstName = firstName;
            Phone = phone;
        }

        [Required]
        public string firstName { get; set; }
        [Required]
        public string phone { get; set; }

    }
}
