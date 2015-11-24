using Data.Models;
using Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        public ActionResult Create(t_flight flight)
        {
            // medtravdbContext db = new medtravdbContext();

            /*     if (ModelState.IsValid)
                 {
                     db.t_flight.Add(flight); //Albums avant
                     db.SaveChanges();
                     return RedirectToAction("Index");
                 }*/

            SelectList flights = new SelectList(new[] { "Abidjan - Port Bouet Airport (ABJ)", "Paris - Paris Charles-de-Gaulle (CDG)", "Malte - Malta International Airport (MLA)" });


            return View(flights);
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

        public ActionResult Ajout()
        {
           // medtravdbContext db = new medtravdbContext();
            //ViewBag.Flights = new SelectList(db.t_flight, "flightId","departureLocation");
            ViewBag.DropDownValues = new SelectList(new[] { "Abidjan - Port Bouet Airport (ABJ)", "Paris - Paris Charles-de-Gaulle (CDG)", "Malte - Malta International Airport (MLA)" });
            return View();
        }
        
 
        public ActionResult Ajout2(t_flight flight)
        {
            medtravdbContext db = new medtravdbContext();
            ViewBag.DropDownValuesDeparture = new SelectList(db.t_flightmatching, "idFlightMatching", "departure");
            ViewBag.DropDownValuesArrival = new SelectList(db.t_flightmatching, "idFlightMatching", "arrival");

            //POUR LES DOUBLONS ET L'ORDRE NON ALPHABETIQUE : ?!
            //ViewBag.DropDownValues = new SelectList(db.t_flightmatching, "idFlightMatching", "departure").Distinct()
            //db.t_flightmatching.OrderBy(t => t.departure).ToList();

            if (ModelState.IsValid)
                {
/*
                if (!String.IsNullOrEmpty(flight.departureLocation.ToString() && flight.arrivalLocation && flight.departureDate && flight.arrivalDate))
                {
                    movies = movies.Where(m => m.Genre.Contains(searchString)).ToList();
                }
                */
                flightService.AddFlight(flight);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
        }
    }
}
