using GameApi.Models;
using GameApi.ViewModels;

namespace GameApi.DAL.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(UserViewModel usr);
    }
}
