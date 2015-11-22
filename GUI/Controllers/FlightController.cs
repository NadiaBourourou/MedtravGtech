using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class FlightController : Controller
    {
        IFlightService flightService;
        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        // GET: Flight
        public ActionResult Index()
        {
            var allFlights = flightService.getAllFlights();
            return View(allFlights);
        }

        // GET: Flight/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flight/Create
        [HttpPost]
        public ActionResult Create(t_flight f)
        {
                if (ModelState.IsValid)
                {
                    flightService.AddFlight(f);
                    return RedirectToAction("Index");
                }
            else
            {
                return View();
            }

        }

        // GET: Flight/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Flight/Edit/5
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

        // GET: Flight/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flight/Delete/5
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
