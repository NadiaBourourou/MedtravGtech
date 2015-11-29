using Data.Models;
using Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class FlightController : Controller
    {
        IFlightService flightService;
        IFlightMatchingService flightMatchingService;

        int userId = 1;

        public FlightController(IFlightService flightService, IFlightMatchingService flightMatchingService)
        {
            this.flightService = flightService;
            this.flightMatchingService = flightMatchingService;
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
            t_flight flight = flightService.GetById(id);
            return View(flight);
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
            medtravdbContext db = new medtravdbContext();
            ViewBag.DropDownValuesDeparture = new SelectList(db.t_flightmatching, "idFlightMatching", "departure");
            ViewBag.DropDownValuesArrival = new SelectList(db.t_flightmatching, "idFlightMatching", "arrival");


            if (ModelState.IsValid)
            {
                flight.patient_userId = userId;

                flightService.AddFlight(flight);
                return RedirectToAction("Index");
            }

            // SelectList flights = new SelectList(new[] { "Abidjan - Port Bouet Airport (ABJ)", "Paris - Paris Charles-de-Gaulle (CDG)", "Malte - Malta International Airport (MLA)" });


            return View();
        }


        // GET: Flight/Edit/5
        public ActionResult Edit(int id)
        {
            t_flight flight = flightService.GetById(id);
            return View(flight);
        }

        // POST: Flight/Edit/5
        [HttpPost]
        public ActionResult Edit(t_flight flight)
        //int id, FormCollection collection
        {
            if (ModelState.IsValid)
            {
                flightService.UpdateFlight(flight);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Flight/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.";
            }

            t_flight flight = flightService.GetById(id);
            return View(flight);
        }

        // POST: Flight/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                t_flight flight = flightService.GetById(id);
                flightService.DeleteFlight(flight);
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

        public ActionResult Ajout()
        {
            // medtravdbContext db = new medtravdbContext();
            //ViewBag.Flights = new SelectList(db.t_flight, "flightId","departureLocation");
            ViewBag.DropDownValues = new SelectList(new[] { "Abidjan - Port Bouet Airport (ABJ)", "Paris - Paris Charles-de-Gaulle (CDG)", "Malte - Malta International Airport (MLA)" });
            return View();
        }


        public ActionResult Ajout2()
        {//, SelectList MyDrownDown1, SelectList MyDrownDown2
            medtravdbContext db = new medtravdbContext();
            ViewBag.DropDownValuesDeparture = new SelectList(db.t_flightmatching, "idFlightMatching", "departure");
            ViewBag.DropDownValuesArrival = new SelectList(db.t_flightmatching, "idFlightMatching", "arrival");



            //POUR LES DOUBLONS ET L'ORDRE NON ALPHABETIQUE : ?!
            //ViewBag.DropDownValues = new SelectList(db.t_flightmatching, "idFlightMatching", "departure").Distinct()
            //db.t_flightmatching.OrderBy(t => t.departure).ToList();

            /*   String dep1 = MyDrownDown1.SelectedValue.ToString();
               String dep2 = MyDrownDown2.SelectedValue.ToString();

               flight.departureLocation = dep1;
               flight.arrivalLocation = dep2;
               */
            //if (ModelState.IsValid)
            //    {

            //    /*
            //    if (!String.IsNullOrEmpty(flight.departureLocation.ToString() && flight.arrivalLocation && flight.departureDate && flight.arrivalDate))
            //    {
            //        movies = movies.Where(m => m.Genre.Contains(searchString)).ToList();
            //    }
            //    */

            //    flightService.AddFlight(flight);
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        return View();
            //    }

            return View();
        }

        [HttpPost]
        public ActionResult Ajout2(string MyDrownDown1, string MyDrownDown2)
        {
            int val1 = Int32.Parse(MyDrownDown1);
            int val2 = Int32.Parse(MyDrownDown2);

            return View();
        }





        // GET: Flight/AddFlight1/5
        public ActionResult AddFlight1()//int id
        {
            // flight flt = flightService.getById(id);
            // Redirect("assignStaffToFlight");
            // int effectif = Int32.Parse(Request.Form.Get("effectif"));

            List<t_flightmatching> flightMatchings = flightMatchingService.getAllFlightsMatching();

            //   getAllFlightsMatchingByDeparture

            List<SelectListItem> listItemDeparture = new List<SelectListItem>();
            List<SelectListItem> listItemArrival = new List<SelectListItem>();

            foreach (t_flightmatching t in flightMatchings)
            {
                listItemDeparture.Add(new SelectListItem() { Value = t.departure, Text = t.idFlightMatching.ToString() });
                listItemArrival.Add(new SelectListItem() { Value = t.arrival, Text = t.idFlightMatching.ToString() });

                //string.Concat(t.departure.Distinct().ToList())
            }

            ViewBag.DropDownValuesDeparture = new SelectList(listItemDeparture, "Text", "Value");
            ViewBag.DropDownValuesArrival = new SelectList(listItemArrival, "Text", "Value");
            return View();


        }

        // POST: Flight/AddFlight1/5
        [HttpPost]
        public ActionResult AddFlight1(string MyListDeparture, string MyListArrival, t_flightmatching flight)//int id,
        {
            t_flightmatching flightDepartureSelectionne = flightMatchingService.GetById(Int32.Parse(MyListDeparture));
            t_flightmatching flightArrivalSelectionne = flightMatchingService.GetById(Int32.Parse(MyListArrival));


            if (ModelState.IsValid)
            {
                // flightService.assignStaffToFlight(flightDepartureSelectionne, flightArrivalSelectionne,flight);
                var myFlights = flightMatchingService.addList(MyListDeparture, MyListArrival, flight);
                //return View(myFlights);

                //  return RedirectToAction("Index");
                return RedirectToAction("Add2Affichage", new { t_flightmatching = myFlights });
            }

            else
            {
                return View();
            }
        }

        public ActionResult Add2Affichage(t_flightmatching myFlights)
        {
            return View(myFlights);
        }






    }
}
