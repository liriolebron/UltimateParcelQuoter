namespace DHLSampleApi.Services
{
    public class UserService : IUserService
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("DHLAdmin") &&
                password.Equals("SuperStrongPassword");
        }
    }
}
