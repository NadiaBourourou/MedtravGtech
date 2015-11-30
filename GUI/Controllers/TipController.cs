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
        int patientId = 1; //à mettre 0 par défaut quand il y aura les sessions
        int adminId = 5;

        public TipController(ITipService tipService)
        {
            this.tipService = tipService;
        }


        //public ActionResult Index() //without research
        //{
        //    ViewBag.connectedAdminId = adminId;
        //    ViewBag.connectedPatientId = patientId;

        //    var allTips = tipService.GetAllTips();
        //    return View(allTips);
        //}

        // GET: Tip
        public ActionResult Index(string optionChoisie = "", string searchTextBox = "")
        {
            ViewBag.connectedAdminId = adminId;
            ViewBag.connectedPatientId = patientId;

            var allTips = tipService.GetAllTips();

            if (optionChoisie == "Title")
            {
                allTips = allTips.Where(s => s.title.ToLower().Contains(searchTextBox.ToLower()) || searchTextBox == null).ToList();
            }
            else
            {
                allTips = allTips.Where(s => s.body.ToLower().Contains(searchTextBox.ToLower()) || searchTextBox == null).ToList();
            }

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

            //tip.idPatientVoted = 0;
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

        // GET: Tip/Appreciate/5
        public ActionResult Appreciate(int id)
        {
            t_tip tip = tipService.GetById(id);
            tipService.PositiveVote(tip, patientId);
            return RedirectToAction("Index");

        }

        // POST: Tip/Appreciate/5
        [HttpPost]
        public ActionResult Appreciate(t_tip tip)
        //int id, FormCollection collection
        {
                return RedirectToAction("Index");  
        }


        // GET: Tip/Dislike/5
        public ActionResult Dislike(int id)
        {
            t_tip tip = tipService.GetById(id);
            tipService.NegativeVote(tip, patientId);
            return RedirectToAction("Index");

        }

        // POST: Tip/Dislike/5
        [HttpPost]
        public ActionResult Dislike(t_tip tip)
        //int id, FormCollection collection
        {
            return RedirectToAction("Index");
        }


    }
}
