using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class ClinicBookingService : IClinicBookingService
    {

        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddClinicBooking(t_clinicbooking a)
        {
            utwk.ClinicBookingRepository.Add(a);
            utwk.Commit();
        }

        public void DeleteClinicBooking(t_clinicbooking a)
        {


            utwk.ClinicBookingRepository.Delete(a);

        }

        public void UpdateClinicBooking(t_clinicbooking a)
        {
            //_repository.Update(entity);
            utwk.ClinicBookingRepository.Update(a);
            utwk.Commit();
        }

        public t_clinicbooking GetById(long id)
        {
            //  return _repository.GetById(id);
            return utwk.ClinicBookingRepository.GetById(id);
        }
        public List<t_clinicbooking> getAllBookingClinics()
        {
            return utwk.ClinicBookingRepository.GetAll().ToList();
        }


    }

    public interface IClinicBookingService
    {
        void AddClinicBooking(t_clinicbooking a);

        void DeleteClinicBooking(t_clinicbooking a);
        t_clinicbooking GetById(long id);
        void UpdateClinicBooking(t_clinicbooking a);
        List<t_clinicbooking> getAllBookingClinics();

    }

}
