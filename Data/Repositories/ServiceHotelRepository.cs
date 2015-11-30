using Data.Infrastructure;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public  class ServiceHotelRepository : RepositoryBase<t_servicehotel>, IServiceHotelRepository
    {
        public ServiceHotelRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

        //  public static IEnumerable<t_servicehotel> ServiceHotelByHotel(this IRepositoryAsync<t_hotel> repository, int id)
        //{
        //    return repository.ProductByCategory(id)
        //        .ToList();
        //}

        //public static IEnumerable<t_servicehotel> ServiceHotelByHotel(this IRepositoryAsync<t_hotel> repository, int id)
        //{
        //    return repository.GetById(id).t_servicehotel.AsEnumerable();
           
        //}
    }

    }
    
    public interface IServiceHotelRepository : IRepository<t_servicehotel>
    {
    //static IEnumerable<t_servicehotel> ServiceHotelByHotel(this IRepositoryAsync<t_hotel> repository, int id);


    //public static IEnumerable<t_servicehotel> ServiceHotelByHotel(this IRepositoryAsync<t_hotel> repository, int id);
    }

