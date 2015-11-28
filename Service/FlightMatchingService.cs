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
        medtravdbContext ctx = null;

        static public DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;

        public FlightMatchingService()
        {
            dbFactory = new DatabaseFactory();
            utwk = new UnitOfWork(dbFactory);

            ctx = new medtravdbContext();
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

        public List<string> getAllFlightsMatchingByDeparture()
        {
            return ctx.t_flightmatching.Select(r => r.departure)
               .Distinct()//sinon on récupère des tables en doublon
               .ToList();
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

        public List<t_flightmatching> addList(string flightDepartureSelectionne, string flightArrivalSelectionne, t_flightmatching flight)
        {
            /* flight flt = unitOfWork.FlightRepository.GetById(idFlight);
             flt.idStaff = stf.id;
             unitOfWork.FlightRepository.Update(flt);
             unitOfWork.Commit();*/

            //    string dep = flightDepartureSelectionne.departure;
            //    string arr = flightArrivalSelectionne.arrival;
            string dateDep = flight.dateFlightMatchingDep;
            string dateArr = flight.dateFlightMatchingArr;

            List<t_flightmatching> listeAmaj = new List<t_flightmatching>();
            List<t_flightmatching> listeTsLesFlights = utwk.FlightMatchingRepository.GetAll().ToList();

            foreach (t_flightmatching f in listeTsLesFlights)
            {
                // if (f.departure == dep && f.arrival == arr && f.dateFlightMatchingDep == dateDep && f.dateFlightMatchingArr == dateArr)
                if (f.departure == flightDepartureSelectionne && f.arrival == flightArrivalSelectionne)

                {
                    listeAmaj.Add(f);

                }
            }

            return listeAmaj;

            //return utwk.FlightMatchingRepository.GetAll().ToList();

        }

    }

    public interface IFlightMatchingService
    {
        void AddFlightMatching(t_flightmatching tf);
        List<t_flightmatching> getAllFlightsMatching();
        t_flightmatching GetById(long id);
        void DeleteFlightMatching(t_flightmatching t);
        void UpdateFlightMatching(t_flightmatching t);

        List<string> getAllFlightsMatchingByDeparture();
        List<t_flightmatching> addList(string flightDepartureSelectionne, string flightArrivalSelectionne, t_flightmatching flight);

    }
}
