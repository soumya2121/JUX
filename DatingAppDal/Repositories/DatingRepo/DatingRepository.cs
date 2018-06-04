using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingAppDal.Context;
using DatingAppDal.Model;
using Microsoft.EntityFrameworkCore;

namespace DatingAppDal.Repositories.DatingRepo
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DatingAppDbContext _context;
        public DatingRepository(DatingAppDbContext context)
        {
            _context= context;
        }
        public  void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int Id)
        {
            var user= await _context.Users.Include(p=>p.Photos).FirstOrDefaultAsync(x=>x.Id==Id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
           var users= await _context.Users.Include(p=>p.Photos).ToListAsync<User>();
           return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() >0;
        }
    }
}