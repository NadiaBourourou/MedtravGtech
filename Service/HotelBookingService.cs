using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HotelBookingService : IHotelBookingService
    {

        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddHotelBooking(t_hotelbooking a)
        {
            utwk.HotelBookingRepository.Add(a);
            utwk.Commit();
        }

        public void DeleteHotelBooking(t_hotelbooking a)
        {


            utwk.HotelBookingRepository.Delete(a);

        }

        public void UpdateHotelBooking(t_hotelbooking a)
        {
            //_repository.Update(entity);
            utwk.HotelBookingRepository.Update(a);
            utwk.Commit();
        }

        public t_hotelbooking GetById(long id)
        {
            //  return _repository.GetById(id);
            return utwk.HotelBookingRepository.GetById(id);
        }
        public List<t_hotelbooking> getAllBookingHotels()
        {
            return utwk.HotelBookingRepository.GetAll().ToList();
        }


    }

    public interface IHotelBookingService
    {
        void AddHotelBooking(t_hotelbooking a);

        void DeleteHotelBooking(t_hotelbooking a);
        t_hotelbooking GetById(long id);
        void UpdateHotelBooking(t_hotelbooking a);
        List<t_hotelbooking> getAllBookingHotels();
    
    }
}
