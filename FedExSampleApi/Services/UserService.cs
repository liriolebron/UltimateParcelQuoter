namespace FedExSampleApi.Services
{
    public class UserService : IUserService
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("FedExAdmin") && 
                password.Equals("SuperStrongPassword");
        }
    }
}
