using Data.Infrastructure;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class SurgeryBookingController : Controller
    {

        public UnitOfWork unitOfWork = new UnitOfWork();
         ISurgeryBookingService ause;
        public SurgeryBookingController(ISurgeryBookingService ause)
        {
            this.ause = ause;
        }

        // GET: SurgeryBooking
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult BookSurgery(int userId, int surgeryId)
        {
            ause.AddSurgeryBooking(userId, surgeryId);
            return RedirectToAction("ListAllDoctors", "User");
        }


    }
}