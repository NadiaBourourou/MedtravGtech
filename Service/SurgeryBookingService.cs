using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{


    public class SurgeryBookingService : ISurgeryBookingService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);

        public void AddSurgeryBooking(int UserId, int SurgeryId)
        {
            t_surgerypatient SurgeryBooking = new t_surgerypatient() { idSurgery = SurgeryId, idPatient = UserId };
            utwk.SurgeryBookingRepository.Add(SurgeryBooking);
            utwk.Commit();
        }
    }

    public interface ISurgeryBookingService
    {
        void AddSurgeryBooking(int UserId, int SurgeryId); // ! on doit ajouter price par la suite - Nadia

    }





}
