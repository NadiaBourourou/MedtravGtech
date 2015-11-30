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
    public class ServiceHotelService : IServiceHotelService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddServiceHotel(t_servicehotel a)
        {
            utwk.ServiceHotelRepository.Add(a);
            utwk.Commit();
        }

        public void DeleteServiceHotel(t_servicehotel a)
        {

            utwk.ServiceHotelRepository.Delete(a);
        }
        public void UpdateServiceHotel(t_servicehotel a)
        {
           
            utwk.ServiceHotelRepository.Update(a);
            utwk.Commit();

        }

        public t_servicehotel GetById(long id)
        {
            //  return _repository.GetById(id);
            return utwk.ServiceHotelRepository.GetById(id);
        }
        public List<t_servicehotel> getAllServicesHotels()
        {
            return utwk.ServiceHotelRepository.GetAll().ToList();
        }

        //public List<t_servicehotel> getAllServicesByHotel(long id)
        //{

        //    return utwk.ServiceHotelRepository.Where(t => t.hotelId ==id ).ToList();
        //}
    }

    public interface IServiceHotelService
    {
        void AddServiceHotel(t_servicehotel a);

        void DeleteServiceHotel(t_servicehotel a);
        t_servicehotel GetById(long id);
        void UpdateServiceHotel(t_servicehotel a);
        List<t_servicehotel> getAllServicesHotels();

        //List<t_servicehotel> getAllServicesByHotel(Expression<Func<T, bool>> int id);

    }
}
