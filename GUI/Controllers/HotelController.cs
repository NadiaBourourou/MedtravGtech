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
    public class HotelController : Controller
    {

        public UnitOfWork unitOfWork = new UnitOfWork();

        IHotelService ause;
        public HotelController(IHotelService ause)
        {
            this.ause = ause;
        }
        // private Data.Models.medtravdbContext = new Models.medtravdbContext();

        // GET: Hotel
        public ActionResult Index()
        {
            var l = ause.getAllHotels();
            return View(l);
        }

        // GET: Hotel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(t_hotel a)
        {

            if (ModelState.IsValid)
            {
                ause.AddHotel(a);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(int id)
        {
            t_hotel hotel = ause.GetById(id);
            return View(hotel);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                t_hotel hotel = ause.GetById(id);
                ause.UpdateHotel(hotel);
                //unitOfWork.Save();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            t_hotel hotel = ause.GetById(id);
            return View(hotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                t_hotel hotel = ause.GetById(id);
                ause.DeleteHotel(hotel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
