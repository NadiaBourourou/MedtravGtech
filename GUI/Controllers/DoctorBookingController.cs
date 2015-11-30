using Data.Infrastructure;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class DoctorBookingController : Controller
    {
        public UnitOfWork unitOfWork = new UnitOfWork();
        IDoctorPatientService ause;
        public DoctorBookingController(IDoctorPatientService ause)
        {
            this.ause = ause;
        }


        public ActionResult BookDoctor(int userId, int doctor)
        {
            ause.AddDoctorBooking(userId, doctor);
            return RedirectToAction("ListAllDoctors", "User"); // à remplacer par la suite : affichage des cliniques / asma
        }
    }
}