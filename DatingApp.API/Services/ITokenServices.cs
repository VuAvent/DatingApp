using DatingApp.API.Database.Entities;

namespace DatingApp.API.Services
{
    public interface ITokenServices
    {
         string CreateToken (User user);
    }
}