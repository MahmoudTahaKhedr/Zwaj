



using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZwajApp.API.Data;
using ZwajApp.API.Interfaces;
using ZwajApp.API.Models;

namespace ZwajApp.API.Services
{
    public class ZwajRepository : IZwajRepository
    {
        private readonly DataContext _context;

        public ZwajRepository(DataContext context)
        {
            _context=context;
        }
        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(x=>x.Photos).FirstOrDefaultAsync(x=>x.Id==id);
            return user;
        }

       public async Task<IEnumerable<User>> GetUsers()
        {
           var users = await _context.Users.Include(x=>x.Photos).ToListAsync();
           return users;
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync()>0;
        }

        
    }
}