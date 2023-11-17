namespace Empetz.API.Public.RequestObject
{
    public class LoginRequest
    {
        public LoginRequest() { }

        public LoginRequest(string Phone)
        {
            Phone = phone;
        }

        public string phone { get; set; }

    }
}
