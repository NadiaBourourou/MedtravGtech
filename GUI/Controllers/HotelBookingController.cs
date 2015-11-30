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
    public class HotelBookingController : Controller
    {
        public UnitOfWork unitOfWork = new UnitOfWork();

        private medtravdbContext db = new medtravdbContext();

        IHotelBookingService ause;
        // GET: HotelBooking
        public ActionResult Index()
        {
            return View();
        }

        // GET: HotelBooking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HotelBooking/Create
        public ActionResult Create()
        {
            ViewBag.HotelId = new SelectList(db.t_hotel, "hotelId", "name");
        //    ViewBag.UserId = new SelectList(db.t_user, "userId", "firstName");
            return View();
        }

        // POST: HotelBooking/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "hotelId, patientId, numNights,roomType, date")] t_hotelbooking hotelBooking)
        {
            if (ModelState.IsValid)
            {
                db.t_hotelbooking.Add(hotelBooking);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelId = new SelectList(db.t_hotel, "hotelId", "name", hotelBooking.hotelId);
         //   ViewBag.UserId = new SelectList(db.t_user, "userId", "firstName", hotelBooking.patientId);
            return View();
        
        }

        // GET: HotelBooking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HotelBooking/Edit/5
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

        // GET: HotelBooking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HotelBooking/Delete/5
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
