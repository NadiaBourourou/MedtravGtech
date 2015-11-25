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
    public class TipController : Controller
    {
        ITipService tipService;
        int patientId = 1;
        int adminId = 5;

        public TipController(ITipService tipService)
        {
            this.tipService = tipService;
        }

        // GET: Tip
        public ActionResult Index()
        {
            var allTips = tipService.GetAllTips();
            return View(allTips);
        }

        // GET: Tip/Details/5
        public ActionResult Details(int id)
        {
            t_tip tip = tipService.GetById(id);
            return View(tip);
        }

        // GET: Tip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tip/Create
        [HttpPost]
        public ActionResult Create(t_tip tip)
        {

            tip.idPatientVoted = patientId;
            tip.administrator_userId = adminId;
            tip.liked = 0;
            tip.disliked = 0;

            if (ModelState.IsValid)
            {
                
                tipService.AddTip(tip);
                return RedirectToAction("Index");
            }


            return View();
        }

        // GET: Tip/Edit/5
        public ActionResult Edit(int id)
        {
            t_tip tip = tipService.GetById(id);
            return View(tip);
        }

        // POST: Tip/Edit/5
        [HttpPost]
        public ActionResult Edit(t_tip tip)
        //int id, FormCollection collection
        {
            if (ModelState.IsValid)
            {
                tipService.UpdateTip(tip);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Tip/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.";
            }

            t_tip tip = tipService.GetById(id);
            return View(tip);
        }

        // POST: Tip/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                t_tip tip = tipService.GetById(id);
                tipService.DeleteTip(tip);
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
