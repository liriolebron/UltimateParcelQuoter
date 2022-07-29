namespace UPSSampleApi.Services
{
    public class UserService : IUserService
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("UPSAdmin") &&
                password.Equals("SuperStrongPassword");
        }
    }
}
