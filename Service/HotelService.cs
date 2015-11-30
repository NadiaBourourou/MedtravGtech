using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void DeleteHotel(t_hotel a)
        {

            
            utwk.HotelRepository.Delete(a);
            utwk.Commit();

        }

        public void UpdateHotel(t_hotel a)
        {
            //_repository.Update(entity);
            utwk.HotelRepository.Update(a);
            utwk.Commit();
            
        }

        public t_hotel GetById(long id)
        {
            //  return _repository.GetById(id);
            return utwk.HotelRepository.GetById(id);
        }
        public List<t_hotel> getAllHotels()
        {
            return utwk.HotelRepository.GetAll().ToList();
        }

        public List<t_hotel> GetHotelsByResearch(string search)
        {
            return utwk.HotelRepository.GetAll().Where(s => s.name.Contains(search)).ToList();
        }

    }

    public interface IHotelService
    {
        void AddHotel(t_hotel a);

        void DeleteHotel(t_hotel a);
        t_hotel GetById(long id);
        void UpdateHotel(t_hotel a);
        List<t_hotel> getAllHotels();
        List<t_hotel> GetHotelsByResearch(string search);
    }
}
