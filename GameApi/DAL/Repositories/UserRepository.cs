using GameApi.DAL.Interfaces;
using GameApi.Models;
using GameApi.ViewModels;

namespace GameApi.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool ValidateUser(UserViewModel usr)
        {
            bool isValidUser;
            var user = User.Users.FirstOrDefault(x => x.Username == usr.Username && x.Password == usr.Password);
            if (user != null)
            {
                isValidUser = true;
            }
            else
            {
                isValidUser = false;
            }
            return isValidUser;
        }
    }
}
