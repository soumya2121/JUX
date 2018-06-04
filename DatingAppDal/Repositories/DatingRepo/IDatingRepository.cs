using System.Collections.Generic;
using System.Threading.Tasks;
using DatingAppDal.Model;

namespace DatingAppDal.Repositories.DatingRepo
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T:class; 
        void Delete<T>(T entity) where T:class; 
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int Id);
        
    }
}