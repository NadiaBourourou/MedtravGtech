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
        medtravdbContext ctx = null;

        static public DatabaseFactory dbFactory = null; 
        UnitOfWork utwk = null; 

        public FlightService()
        {
            dbFactory= new DatabaseFactory();
            utwk= new UnitOfWork(dbFactory);

            ctx = new medtravdbContext();
        }
        public void AddFlight(t_flight f)
        {
            utwk.FlightRepository.Add(f);
            utwk.Commit();
        }


        public List<t_flight> getAllFlights()
        {
            return utwk.FlightRepository.GetAll().ToList();
        }

        public t_flight GetById(long id)
        {
            return utwk.FlightRepository.GetById(id);
        }

        public void DeleteFlight(t_flight t)
        {
            utwk.FlightRepository.Delete(t);
            utwk.Commit();
        }

        public void UpdateFlight(t_flight t)
        {
            utwk.FlightRepository.Update(t);
            utwk.Commit();
        }

        public List<t_flight> getAllFlightsOfThatPatient(int idPatient)
        {
            return ctx.t_flight.Where(r => r.patient_userId == idPatient).ToList();
        }

        public t_flight GetMYflightDetails(int id, int patientId)
        {
            List<t_flight> listeTsLesFlights = utwk.FlightRepository.GetAll().ToList();
            t_flight myFlightFound = new t_flight();

            foreach (t_flight f in listeTsLesFlights)
            {

                if (f.flightId == id && f.patient_userId == patientId)

                {
                    myFlightFound = f;

                }
            }

            return myFlightFound;

        }
    }

    public interface IFlightService
    {
        void AddFlight(t_flight f);
        List<t_flight> getAllFlights();
        t_flight GetById(long id);
        void DeleteFlight(t_flight t);
        void UpdateFlight(t_flight t);

        List<t_flight> getAllFlightsOfThatPatient(int idPatient);

        t_flight GetMYflightDetails(int id, int patientId);
    }



}
