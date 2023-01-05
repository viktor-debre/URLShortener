using URLShortener.Models.Entities;

namespace URLShortener.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<User> AuthenticateUser(string login, string password);

        public Task<bool> RegisterUser(string login, string password);

        public Task<User?> GetUserByName(string login);
    }
}
