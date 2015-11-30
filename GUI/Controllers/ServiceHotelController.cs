using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class ServiceHotelController : Controller
    {
        IServiceHotelService ause;
        public ServiceHotelController(IServiceHotelService ause)
        {
            this.ause = ause;
        }
        // GET: ServiceHotel
        public ActionResult IndexServiceHotel()
        {
            var l = ause.getAllServicesHotels();
            return View(l);
        }

        // GET: ServiceHotel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceHotel/Create
        public ActionResult Create()
        {
            //medtravdbContext db = new medtravdbContext();
            //ViewData[« hotel_hotelId »] = new SelectList(db.t_hotel, « hotel_hotelId », « t_hotel.name »);
            //t_servicehotel game = new t_servicehotel();
            //return View(game);
            return View();

        }

        // POST: ServiceHotel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceHotel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceHotel/Edit/5
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

        // GET: ServiceHotel/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.";
            }

            t_servicehotel s = ause.GetById(id);
            return View(s);
        }

        // POST: ServiceHotel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            {
                try
                {
                    t_servicehotel s = ause.GetById(id);
                    ause.DeleteServiceHotel(s);


                }
                catch (DataException)
                {
                    return RedirectToAction("Delete",
                       new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
                }
                return RedirectToAction("Index");
            }
        }
    }
}
