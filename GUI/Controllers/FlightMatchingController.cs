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
    public class FlightMatchingController : Controller
    {
        IFlightMatchingService flightMatchingService;

        public FlightMatchingController(IFlightMatchingService flightMatchingService)
        {
            this.flightMatchingService = flightMatchingService;
        }
        
        // GET: FlightMatching
        public ActionResult Index()
        {
            var allFlightsMatching = flightMatchingService.getAllFlightsMatching();
            return View(allFlightsMatching);
        }

        // GET: FlightMatching/Details/5
        public ActionResult Details(int id)
        {
            t_flightmatching flightMatching = flightMatchingService.GetById(id);
            return View(flightMatching);
        }

        // GET: FlightMatching/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlightMatching/Create
        [HttpPost]
        public ActionResult Create(t_flightmatching flightMatching)
        {
            if (ModelState.IsValid)
            {

                flightMatchingService.AddFlightMatching(flightMatching);
                return RedirectToAction("Index");
            }


            return View();
        }

        // GET: FlightMatching/Edit/5
        public ActionResult Edit(int id)
        {
            t_flightmatching flightMatching = flightMatchingService.GetById(id);
            return View(flightMatching);
        }

        // POST: FlightMatching/Edit/5
        [HttpPost]
        public ActionResult Edit(t_flightmatching flightMatching)
        //int id, FormCollection collection
        {
            if (ModelState.IsValid)
            {
                flightMatchingService.UpdateFlightMatching(flightMatching);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: FlightMatching/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.";
            }

            t_flightmatching flightMatching = flightMatchingService.GetById(id);
            return View(flightMatching);
        }

        // POST: FlightMatching/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                t_flightmatching flightMatching = flightMatchingService.GetById(id);
                flightMatchingService.DeleteFlightMatching(flightMatching);
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
