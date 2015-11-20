using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HotelService : IHotelService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddHotel(t_hotel a)
        {
            utwk.HotelRepository.Add(a);
            utwk.Commit();
        }

        public List<t_hotel> getAllHotels()
        {
            return utwk.HotelRepository.GetAll().ToList();
        }
    }

    public interface IHotelService
    {
        void AddHotel(t_hotel a);
        List<t_hotel> getAllHotels();
    }
}
