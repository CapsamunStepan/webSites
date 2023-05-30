using Qitchen.Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace Qitchen.BusinessLogic.Service
{
    public class MenuService : Service
	{
        public EntryServiceResponse<Menu> GetByName(string name)
        {
            var i = DbContext.Menu.ToList();
            var menu = DbContext.Menu
                .Include(x => x.Products)
                .FirstOrDefault(x => x.Name == name);

            return Entry(menu);
        }

        public ServiceResponse Edit(Menu user)
        {
            DbContext.Entry(user).State = EntityState.Modified;
            DbContext.SaveChanges();
            return Success();
        }

        public ServiceResponse Delete(Menu user)
        {
            DbContext.Entry(user).State = EntityState.Deleted;
            DbContext.SaveChanges();
            return Success();
        }
    }
}
