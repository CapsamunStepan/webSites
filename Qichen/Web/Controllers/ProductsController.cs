using BusinessLogic.DB;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Products()
        {
            KitchenEntities kitchenEntities = new KitchenEntities();
            List<Item> items = kitchenEntities.Items.ToList();
            ItemsModel model = new ItemsModel();
            model.Items = items;

            return View(model);
        }
        [HttpPost]
        public ActionResult Products(int Item_ID)
        {
            KitchenEntities re = new KitchenEntities();
            Item it = re.Items.Find(Item_ID);

            var _user = re.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            Cart cart = re.Carts.Where(model => model.User_ID == _user.User_ID).FirstOrDefault();
            if (cart == null)
            {
                cart = new Cart
                {
                    Cart_Total = 1,
                    User_ID = _user.User_ID,
                };
                re.Carts.Add(cart);
                re.SaveChanges();
            }
            CartItem cartItem = new CartItem();
            cartItem.Cart_ID = cart.Cart_ID;
            cartItem.Item_ID = Item_ID;
            cartItem.Item_Amount = 1;
            re.CartItems.Add(cartItem);
            re.SaveChanges();

            return RedirectToAction("Products");
        }
    }
}