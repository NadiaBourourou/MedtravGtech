using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.Infrastructure;

namespace Service
{
    public class FlightService : IFlightService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);

        public void AddFlight(t_flight f)
        {
            utwk.FlightRepository.Add(f);
            utwk.Commit();
        }

        public List<t_flight> getAllFlights()
        {
            return utwk.FlightRepository.GetAll().ToList();
        }
    }

    public interface IFlightService
    {
        void AddFlight(t_flight f);
        List<t_flight> getAllFlights();
    }

}
