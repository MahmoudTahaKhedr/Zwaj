using System.Threading.Tasks;
using ZwajApp.API.Models;

namespace ZwajApp.API.Interfaces
{
    public interface IAuthRepository
    {
         Task<User>Register(User user,string password);
         Task<User>Login(string username,string password);
         Task<bool>UserExists(string username);
    }
}