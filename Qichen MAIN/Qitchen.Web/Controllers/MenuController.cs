using Qitchen.BusinessLogic.Service;
using Qitchen.Web.Models;
using System.Web.Mvc;

namespace Qitchen.Web.Controllers
{
    public class MenuController : BaseController
    {
        public ActionResult Details(string id)
        {
            var menuService = new MenuService();
            var menuResp = menuService.GetByName(id);
            if (!menuResp.Success)
                return HttpNoPermission();

            var menu = menuResp.Entry;
            if (menu == null)
                return HttpNotFound();

            return View(menu);
        }
    }
}