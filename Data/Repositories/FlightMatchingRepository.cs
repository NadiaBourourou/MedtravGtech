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
    public class FlightMatchingRepository : RepositoryBase<t_flightmatching>, IFlightMatchingRepository
    {
        public FlightMatchingRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface IFlightMatchingRepository : IRepository<t_flightmatching>
    {

    }
}
