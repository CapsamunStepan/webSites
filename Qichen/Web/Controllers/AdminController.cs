using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            KitchenEntities db = new KitchenEntities();
            return View(db.Items);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase itemPhoto, string itemName, string itemPrice)
        {
            KitchenEntities db = new KitchenEntities();

            Item item = new Item();
            item.Item_Price = float.Parse(itemPrice);
            item.Item_Name = itemName;

            if (itemPhoto != null && itemPhoto.ContentLength > 0)
            {
                string fileName = Path.GetFileName(itemPhoto.FileName);
                string filePath = Path.Combine(Server.MapPath("~/Content/images/product"), fileName);
                itemPhoto.SaveAs(filePath);
                item.Item_Image = "/Content/images/product/" + fileName;
                // Additional processing or saving logic here
            }

            db.Items.Add(item);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            KitchenEntities db = new KitchenEntities();
            Item model = db.Items.Find(id);
            if (model != null)
            {
                List<CartItem> cartitem = db.CartItems.Where(s => s.Item_ID == id).ToList();
                foreach (var item in cartitem)
                {
                    db.CartItems.Remove(item);
                }
                db.Items.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            KitchenEntities db = new KitchenEntities();
            Item us = db.Items.Find(id);
            ViewBag.isEdit = true;
            return View("Edit", us);
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase itemPhoto, string itemName, string itemPrice, int Item_ID)
        {
            KitchenEntities db = new KitchenEntities();

            Item us = db.Items.Find(Item_ID);
            us.Item_Name = itemName;
            us.Item_Price = float.Parse(itemPrice);

            if (itemPhoto != null && itemPhoto.ContentLength > 0)
            {
                string fileName = Path.GetFileName(itemPhoto.FileName);
                string filePath = Path.Combine(Server.MapPath("~/Content/images/product"), fileName);
                itemPhoto.SaveAs(filePath);
                us.Item_Image = "/Content/images/product/" + fileName;
                // Additional processing or saving logic here
            }


            db.Entry<Item>(us).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}