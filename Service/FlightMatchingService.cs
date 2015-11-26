using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FlightMatchingService : IFlightMatchingService
    {
        static public DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;

        public FlightMatchingService() {
            dbFactory = new DatabaseFactory();
            utwk = new UnitOfWork(dbFactory);
        }
        public void AddFlightMatching(t_flightmatching tf)
        {
            utwk.FlightMatchingRepository.Add(tf);
            utwk.Commit();
        }

        public void DeleteFlightMatching(t_flightmatching t)
        {
            utwk.FlightMatchingRepository.Delete(t);
            utwk.Commit();
        }

        public List<t_flightmatching> getAllFlightsMatching()
        {
            return utwk.FlightMatchingRepository.GetAll().ToList();
        }

        public t_flightmatching GetById(long id)
        {
            return utwk.FlightMatchingRepository.GetById(id);
        }

        public void UpdateFlightMatching(t_flightmatching t)
        {
            utwk.FlightMatchingRepository.Update(t);
            utwk.Commit();
        }
    }

    public interface IFlightMatchingService
    {
        void AddFlightMatching(t_flightmatching tf);
        List<t_flightmatching> getAllFlightsMatching();
        t_flightmatching GetById(long id);
        void DeleteFlightMatching(t_flightmatching t);
        void UpdateFlightMatching(t_flightmatching t);
    }
}
