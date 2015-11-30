﻿using Data.Infrastructure;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
   public  class HotelBookingRepository : RepositoryBase<t_hotelbooking>, IHotelBookingRepository
    {
        public HotelBookingRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
    public interface IHotelBookingRepository : IRepository<t_hotelbooking>
    {

    }
}