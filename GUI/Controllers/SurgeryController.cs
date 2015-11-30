using Data.Infrastructure;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class SurgeryController : Controller
    {
        // GET: Surgery
        
            public UnitOfWork unitOfWork = new UnitOfWork();

            ISurgeryService ause;
            public SurgeryController(ISurgeryService ause)
            {
                this.ause = ause;
            }

            public ActionResult Index()
            {
            var  all = ause.GetSurgeries();
            return View(all);
            }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var all = ause.GetSurgeries();

            if (!String.IsNullOrEmpty(search))
            {
                all = ause.GetSurgeriesByResearch(search);
            }

            return View(all);
        }













        // GET: Surgery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Surgery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surgery/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Surgery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Surgery/Edit/5
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

        // GET: Surgery/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Surgery/Delete/5
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
