using BusinessLogic.DB;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class RezervationController : Controller
    {
        // GET: Rezervation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sucess(string number, string phone, string date, string time)
        {
            KitchenEntities db = new KitchenEntities();

            Reservation rezervation = new Reservation();
            rezervation.Reserv_Number = int.Parse(number);
            rezervation.Reserv_Date = DateTime.Now;
            rezervation.Reserv_Time = TimeSpan.Parse(time);

            if (db.Reservations
                .Where(m => m.Reserv_Time == rezervation.Reserv_Time && m.Reserv_Date == rezervation.Reserv_Date)
                .FirstOrDefault() != null)
            {
                return View();
            }

            else
            {
                db.Reservations.Add(rezervation);
                db.SaveChanges();

                BookedModel bModel = new BookedModel();
                bModel.number = number;
                bModel.time = time;
                bModel.date = date;
                bModel.phone = phone;
                return View(bModel);
            }
        }

        [HttpGet]
        public ActionResult Sucess()
        {
            return View();
        }
    }
}