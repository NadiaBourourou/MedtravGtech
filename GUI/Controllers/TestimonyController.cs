using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class TestimonyController : Controller
    {
        ITestimonyService testimonyService;
        int userId=1;

        public TestimonyController(ITestimonyService testimonyService)
        {
            this.testimonyService = testimonyService;
        }

        // GET: Testimony
        public ActionResult Index()
        {
            var allTestimonies = testimonyService.getAllTestimonies();
            return View(allTestimonies);
            
        }

        // GET: Testimony/Details/5
        public ActionResult Details(int id)
        {
            t_testimony testimony = testimonyService.GetById(id);
            return View(testimony);
        }

        // GET: Testimony/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Testimony/Create
        [HttpPost]
        public ActionResult Create(t_testimony t)
        {

            if (ModelState.IsValid)
            {
                t.date = DateTime.Now;
                t.patient_userId =userId;

                testimonyService.AddTestimony(t);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Testimony/Edit/5
        public ActionResult Edit(int id)
        {
            t_testimony testimony = testimonyService.GetById(id);
            return View(testimony);
        }

        // POST: Testimony/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            try
            {
                t_testimony testimony = testimonyService.GetById(id);
                testimonyService.UpdateTestimony(testimony);
            
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Testimony/Delete/5
        public ActionResult Delete(bool? saveChangesError = false, int id=0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Please try again.";
            }

            t_testimony testimony = testimonyService.GetById(id);
            return View(testimony);
        }

        // POST: Testimony/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                t_testimony testimony = testimonyService.GetById(id);
                testimonyService.DeleteTestimony(testimony);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
