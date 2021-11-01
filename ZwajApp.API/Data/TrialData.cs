using System.Collections.Generic;
using Newtonsoft.Json;
using ZwajApp.API.Models;

namespace ZwajApp.API.Data
{
    public class TrialData
    {
        
        private readonly DataContext _context;

        public TrialData(DataContext context)
        {
            _context = context;

        }

        public void TrialUser(){
            var userData=System.IO.File.ReadAllText("Data/UsersTrialData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                 byte[] passwordHash, passordSalt;
                 createPasswordHash("password",out passwordHash,out passordSalt);
                 user.PasswordHash=passwordHash;
                 user.PasswordSalt=passordSalt;
                 user.UserName=user.UserName.ToLower();
                 _context.Add(user);
                 
            }
            _context.SaveChanges();
        }
         private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using( var hmac = new System.Security.Cryptography.HMACSHA512()){
               passwordSalt =hmac.Key;
               passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
           }
           
        }
    }
}