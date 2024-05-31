using GameApi.Models;
using GameApi.ViewModels;

namespace GameApi.DAL.Interfaces
{
    public interface IUserRepository
    {
        public bool ValidateUser(UserViewModel user);
    }
}
