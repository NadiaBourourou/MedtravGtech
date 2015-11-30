using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DoctorPatientService : IDoctorPatientService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);

        public void AddDoctorBooking(int userId, int doctorId)
        {

            t_doctorpatient DoctorBooking = new t_doctorpatient() { doctorId = doctorId, patientId = userId };
             utwk.DoctorPatientRepository.Add(DoctorBooking);

        }
    }

    public interface IDoctorPatientService
    {
    void AddDoctorBooking (int userId, int doctorId);
    
    }


}
