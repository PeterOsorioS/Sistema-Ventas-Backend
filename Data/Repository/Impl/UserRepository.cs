using Data.Context;
using Data.Repository.Interface;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Impl
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }

        public async Task UpdateInfo(User user)
        {
            var userDb = _db.users.FirstOrDefault(u => u.Id == user.Id);
            if (userDb != null)
            {
                userDb.FirstName = user.FirstName;
                user.LastName = user.LastName;
                userDb.Email = user.Email;
                user.Birthday = user.Birthday;
                _db.users.Update(userDb);
                await _db.SaveChangesAsync();
            }
        }

        public async Task UpdatePassword(User user)
        {
            var userDb = _db.users.FirstOrDefault(u=>u.Id == user.Id);
            if (userDb != null) 
            {
                userDb.Password = user.Password;
                _db.users.Update(userDb);
                await _db.SaveChangesAsync();
            }
        }
    }
}
