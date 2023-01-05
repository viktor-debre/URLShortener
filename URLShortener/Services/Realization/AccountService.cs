using URLShortener.DAO.Interfaces;
using URLShortener.Models;
using URLShortener.Models.Entities;
using URLShortener.Services.Interfaces;

namespace URLShortener.Services.Realization
{
    public class AccountService : IAccountService
    {
        public IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> AuthenticateUser(string login, string password)
        {
            var usersList = await _unitOfWork.Users.GetAll();
            var user = usersList.FirstOrDefault(user => user.Login == login && user.Password == password);

            return user;
        }

        public async Task<bool> RegisterUser(string login, string password)
        {
            var usersList = await _unitOfWork.Users.GetAll();
            var user = usersList.FirstOrDefault(user => user.Login == login && user.Password == password);

            if (user == null)
            {
                
                await _unitOfWork.Users.Add(new User {Login = login, Password = password, Role = "user" });

                var result = _unitOfWork.Save();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
