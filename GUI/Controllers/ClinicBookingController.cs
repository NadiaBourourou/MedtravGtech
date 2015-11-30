using Data.Infrastructure;
using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class ClinicBookingController : Controller
    {
        public UnitOfWork unitOfWork = new UnitOfWork();


        IClinicBookingService ause;

        private medtravdbContext db = new medtravdbContext();

        public ClinicBookingController(IClinicBookingService ause)
        {
            this.ause = ause;
        }
        // GET: ClinicBooking
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClinicBooking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicBooking/Create
        public ActionResult Create()
        {
            ViewBag.ClinicId = new SelectList(db.t_clinic, "clinicId", "name");
            //    ViewBag.UserId = new SelectList(db.t_user, "userId", "firstName");
            return View();
        }

        // POST: ClinicBooking/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "clinicId, patientId, commentaire,typeRoom, date")] t_clinicbooking clinicBooking)
        {
            if (ModelState.IsValid)
            {
                ause.AddClinicBooking(clinicBooking);
              //  db.t_clinicbooking.Add(clinicBooking);

              //  db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelId = new SelectList(db.t_clinic, "clinicId", "name", clinicBooking.clinicId);
            //   ViewBag.UserId = new SelectList(db.t_user, "userId", "firstName", hotelBooking.patientId);
            return View();

        }

        // GET: ClinicBooking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClinicBooking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClinicBooking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClinicBooking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
