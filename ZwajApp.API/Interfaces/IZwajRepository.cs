using System.Collections.Generic;
using System.Threading.Tasks;
using ZwajApp.API.Models;


namespace ZwajApp.API.Interfaces 

{
    public interface IZwajRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}