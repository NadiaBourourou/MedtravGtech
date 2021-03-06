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
    public class HotelRepository : RepositoryBase<t_hotel>, IHotelRepository
    {
        public HotelRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
    public interface IHotelRepository : IRepository<t_hotel>
    {

    }
}
