using Qitchen.Domain.Entities;
using System.Data.Entity;

namespace Qitchen.BusinessLogic.Database
{
	public class DbContext : System.Data.Entity.DbContext
	{
		public DbContext()
			: base("name=Qitchen") { }

		public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}