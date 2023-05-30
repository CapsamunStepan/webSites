using Qitchen.Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace Qitchen.BusinessLogic.Service
{
    public class UserService : Service
	{
        public EntryServiceResponse<User> GetById(int id)
        {
            return Entry(DbContext.Users.FirstOrDefault(x => x.Id == id));
        }

        public EntryServiceResponse<User> GetByEmail(string email)
        {
            return Entry(DbContext.Users.FirstOrDefault(x => x.Email == email));
        }

        public ServiceResponse Edit(User user)
        {
            DbContext.Entry(user).State = EntityState.Modified;
            DbContext.SaveChanges();
            return Success();
        }

        public ServiceResponse Delete(User user)
        {
            DbContext.Entry(user).State = EntityState.Deleted;
            DbContext.SaveChanges();
            return Success();
        }

        public EntriesServiceResponse<User> GetAll()
        {
            return Entries(DbContext.Users.ToList());
        }
    }
}
