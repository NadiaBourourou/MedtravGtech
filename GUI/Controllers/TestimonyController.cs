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
            return View();
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
            return View();
        }

        // POST: Testimony/Edit/5
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

        // GET: Testimony/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Testimony/Delete/5
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
