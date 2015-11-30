using Data;
using Data.Infrastructure;
using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class HotelController : Controller
    {

        public UnitOfWork unitOfWork = new UnitOfWork();

        IHotelService ause;
        public HotelController(IHotelService ause)
        {
            this.ause = ause;
        }
        // private Data.Models.medtravdbContext = new Models.medtravdbContext();

        // GET: Hotel
        public ActionResult Index()
        {
            var l = ause.getAllHotels();
            return View(l);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var all = ause.getAllHotels();

            if (!String.IsNullOrEmpty(search))
            {
                all = ause.GetHotelsByResearch(search);
            }

            return View(all);
        }


        // GET: Hotel
        public ActionResult IndexPatient()
        {
            var l = ause.getAllHotels();
            return View(l);
        }

        [HttpPost]
        public ActionResult IndexPatient(string search)
        {
            var all = ause.getAllHotels();

            if (!String.IsNullOrEmpty(search))
            {
                all = ause.GetHotelsByResearch(search);
            }

            return View(all);
        }

        // GET: Hotel/Details/5
        public ActionResult Details(int id)
        {
            var hotel = ause.GetById(id);
            return View(hotel);
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(t_hotel a, HttpPostedFileBase ImageId)
        {
            if (ModelState.IsValid) {
                if (ImageId != null)
                {
                    ImageId.SaveAs(HttpContext.Server.MapPath("~/Upload/")
                                                          + ImageId.FileName);
                    a.ImgName = ImageId.FileName;
                    //
                   
                }

               ause.AddHotel(a);
                //    var path = Path.Combine(Server.MapPath("~/Upload/"), ImageId.FileName);
                //    ImageId.SaveAs(path);

          


                return RedirectToAction("Index");
            }
            else
            {
                return View();
           }
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(int id)
        {
            t_hotel hotel = ause.GetById(id);
            return View(hotel);
            
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(t_hotel c)
        {
            //if (ModelState.IsValid)
            //{
            try {
                ause.UpdateHotel(c);
                return RedirectToAction("Index");
            }
            catch { return View(); }
            //}
            //else
            //{
            //    return View();
            //}
            
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(bool? saveChangesError, int id)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            t_hotel hotel = ause.GetById(id);
            return View(hotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                t_hotel hotel=ause.GetById(id);
                ause.DeleteHotel(hotel);
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
