using Qitchen.Domain.Entities;
using Qitchen.Helpers;
using System.Collections.Generic;
using System.Data.Entity;

namespace Qitchen.BusinessLogic.Database
{
    public class DbInitializer : DropCreateDatabaseAlways<DbContext>
	{
		protected override void Seed(DbContext context)
        {
            var admin = context.Users.Add(new User()
            {
                Name = "Admin Admin",
                PasswordHash = AuthHelper.GeneratePasswordHash("admin"),
                Email = "admin@admin.md",
                Role = UserRole.Admin
            });
            var user = context.Users.Add(new User()
            {
                Name = "User User",
                PasswordHash = AuthHelper.GeneratePasswordHash("user"),
                Email = "user@user.md"
            });

            //---------------------------------------------------//

            context.Menu.Add(new Menu
            {
                Name = "fastfood",
                Title = "Fast Food",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Title = "Wasabi Burger",
                        Image = "/Content/images/menu/thumb-1.png",
                        Price = 25
                    },
                    new Product()
                    {
                        Title = "Pizza Rossini",
                        Image = "/Content/images/menu/thumb-2.png",
                        Price = 63
                    },
                    new Product()
                    {
                        Title = "Baked Chicken Wings",
                        Image = "/Content/images/menu/thumb-3.png",
                        Price = 99
                    },
                    new Product()
                    {
                        Title = "Seafood Pizza",
                        Image = "/Content/images/menu/thumb-4.png",
                        Price = 52
                    }
                }
            });

            context.Menu.Add(new Menu
            {
                Name = "seafood",
                Title = "Sea Food",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Title = "Red King Crab",
                        Image = "/Content/images/menu/thumb-9.png",
                        Price = 65
                    },
                    new Product()
                    {
                        Title = "Alaskan King Crab",
                        Image = "/Content/images/menu/thumb-10.png",
                        Price = 73
                    },
                    new Product()
                    {
                        Title = "Boston Lobster",
                        Image = "/Content/images/menu/thumb-11.png",
                        Price = 45
                    },
                    new Product()
                    {
                        Title = "Flat-lay Delicious",
                        Image = "/Content/images/menu/thumb-12.png",
                        Price = 49
                    }
                }
            });

            base.Seed(context);
		}
	}
}