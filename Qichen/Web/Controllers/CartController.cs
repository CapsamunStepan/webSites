using BusinessLogic.DB;
using Domain;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        [Authorize]
        public ActionResult Index()
        {
            KitchenEntities re = new KitchenEntities();

            var _user = re.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            // get cart
            Cart cart = re.Carts
                .Where(model => model.User_ID == _user.User_ID)
                .FirstOrDefault();

            if (cart != null)
            {
                List<Item> items = re.CartItems
                    .Where(model => model.Cart_ID == cart.Cart_ID)
                    .Select(model => model.Item)
                    .ToList();

                List<CartItem> cartItems = re.CartItems
                    .Where(model => model.Cart_ID == cart.Cart_ID)
                    .ToList();

                List<AdditionalItem> additionalItems = new List<AdditionalItem>();
                double sum = 0;
                foreach (var entry in cartItems)
                {
                    AdditionalItem additionalItem = new AdditionalItem
                    {
                        item = entry.Item,
                        itemAmount = entry.Item_Amount,
                    };

                    additionalItems.Add(additionalItem);
                    sum += entry.Item.Item_Price * entry.Item_Amount;
                }
                //List<CartItem> cItems = re.CartItems.Where(model => model.Cart.User_ID == _user.User_ID).ToList();

                // calculate total price
                // pass only items

                CartItemsModel theModel = new CartItemsModel();
                theModel.cartItems = additionalItems;
                theModel.Cart_ID = cart.Cart_ID;
                theModel.TotalPrice = Math.Round(sum, 2);

                TempData["amountTotal"] = cartItems.Count;
                return View(theModel);
            }
            //else { return RedirectToAction("","Products"); }
            else
            {
                return View("");
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            // first find the user V
            // then get the cart ID  V
            // in cart item get items related to the cart ID
            // remove the item with that ID FROM cartitem table
            var re = new KitchenEntities();

            var _user = re.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            var _cart = re.Carts.Where(s => s.User_ID == _user.User_ID).FirstOrDefault();

            var _cartItem = re.CartItems.Where(s => s.Item_ID == id && _cart.Cart_ID == s.Cart_ID).FirstOrDefault();

            re.CartItems.Remove(_cartItem);
            re.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Increment(CartItemsModel theModelInc, int Item_ID, int Cart_ID)
        {
            var re = new KitchenEntities();

            // first need to find the cartItem_ID
            CartItem cartItem = re.CartItems
                .Where(model => model.Cart_ID == Cart_ID && model.Item_ID == Item_ID)
                .FirstOrDefault();

            cartItem.Item_Amount++;
            re.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Decrement(CartItemsModel theModelDec, int Item_ID, int Cart_ID)
        {
            var re = new KitchenEntities();

            // first need to find the cartItem_ID
            CartItem cartItem = re.CartItems
                .Where(model => model.Cart_ID == Cart_ID && model.Item_ID == Item_ID)
                .FirstOrDefault();

            if (cartItem.Item_Amount == 1)
            {
                return RedirectToAction("Delete", new { id = Item_ID });
            }
            else
            {
                cartItem.Item_Amount--;
                re.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Checkout()
        {
            KitchenEntities re = new KitchenEntities();

            var _user = re.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            // get cart
            Cart cart = re.Carts
                .Where(model => model.User_ID == _user.User_ID)
                .FirstOrDefault();

            List<Item> items = re.CartItems
                .Where(model => model.Cart_ID == cart.Cart_ID)
                .Select(model => model.Item)
                .ToList();

            List<CartItem> cartItems = re.CartItems
                .Where(model => model.Cart_ID == cart.Cart_ID)
                .ToList();

            List<AdditionalItem> additionalItems = new List<AdditionalItem>();
            double sum = 0;
            foreach (var entry in cartItems)
            {
                AdditionalItem additionalItem = new AdditionalItem
                {
                    item = entry.Item,
                    itemAmount = entry.Item_Amount,
                };

                additionalItems.Add(additionalItem);
                sum += entry.Item.Item_Price * entry.Item_Amount;
            }
            //List<CartItem> cItems = re.CartItems.Where(model => model.Cart.User_ID == _user.User_ID).ToList();

            // calculate total price
            // pass only items

            CartItemsModel theModel = new CartItemsModel();
            theModel.cartItems = additionalItems;
            theModel.Cart_ID = cart.Cart_ID;
            theModel.TotalPrice = Math.Round(sum, 2);
            return View(theModel);
        }
        [HttpPost]
        public ActionResult Payment(string first_name, string last_name, string number, string email, string city, string street_name, string payment)
        {
            KitchenEntities re = new KitchenEntities();

            var _user = re.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            // get cart
            Cart cart = re.Carts
                .Where(model => model.User_ID == _user.User_ID)
                .FirstOrDefault();

            List<Item> items = re.CartItems
                .Where(model => model.Cart_ID == cart.Cart_ID)
                .Select(model => model.Item)
                .ToList();

            List<CartItem> cartItems = re.CartItems
                .Where(model => model.Cart_ID == cart.Cart_ID)
                .ToList();

            List<AdditionalItem> additionalItems = new List<AdditionalItem>();
            double sum = 0;
            foreach (var entry in cartItems)
            {
                AdditionalItem additionalItem = new AdditionalItem
                {
                    item = entry.Item,
                    itemAmount = entry.Item_Amount,
                };

                additionalItems.Add(additionalItem);
                sum += entry.Item.Item_Price * entry.Item_Amount;
            }
            //List<CartItem> cItems = re.CartItems.Where(model => model.Cart.User_ID == _user.User_ID).ToList();

            // calculate total price
            // pass only items

            CartItemsModel theModel = new CartItemsModel();
            theModel.cartItems = additionalItems;
            theModel.Cart_ID = cart.Cart_ID;
            theModel.TotalPrice = Math.Round(sum, 2);

            ItemsAndPersonalDataModel data = new ItemsAndPersonalDataModel
            {
                Model = theModel,
                City = city,
                Email = email,
                Name = first_name,
                Surname = last_name,
                Number = number,
                Payment = payment,
                Street_name = street_name
            };
            return View(data);
        }
        [HttpGet]
        public ActionResult Payment()
        {
            return View();
        }
    }
}