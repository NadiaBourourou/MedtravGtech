using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MedicalRecordsService : IMedicalRecordsService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddMedicalRecords(t_medicalrecords a)
        {
            utwk.MedicalRecordsRepository.Add(a);
            utwk.Commit();
        }

        public void DeleteMedicalRecords(t_medicalrecords a)
        {
            utwk.MedicalRecordsRepository.Delete(a);
            utwk.Commit();
        }

        public List<t_medicalrecords> getAllMedicalRecords()
        {
            return utwk.MedicalRecordsRepository.GetAll().ToList();
        }

        public t_medicalrecords GetById(long id)
        {
            return utwk.MedicalRecordsRepository.GetById(id);
        }

        public void UpdateMedicalRecords(t_medicalrecords a)
        {
            utwk.MedicalRecordsRepository.Update(a);
            utwk.Commit();
        }
    }

    public interface IMedicalRecordsService
    {
        void AddMedicalRecords(t_medicalrecords a);

        void DeleteMedicalRecords(t_medicalrecords a);
        t_medicalrecords GetById(long id);
        void UpdateMedicalRecords(t_medicalrecords a);
        List<t_medicalrecords> getAllMedicalRecords();
    }
}
