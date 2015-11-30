using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
 public   class ClinicService : IClinicService
    {

        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddClinic(t_clinic a)
        {
            utwk.ClinicRepository.Add(a);
            utwk.Commit();
        }

        public void DeleteClinic(t_clinic a)
        {


            utwk.ClinicRepository.Delete(a);

        }

        public void UpdateClinic(t_clinic a)
        {
            //_repository.Update(entity);
            utwk.ClinicRepository.Update(a);
            utwk.Commit();
        }

        public t_clinic GetById(long id)
        {
            //  return _repository.GetById(id);
            return utwk.ClinicRepository.GetById(id);
        }
        public List<t_clinic> getAllClinics()
        {
            return utwk.ClinicRepository.GetAll().ToList();
        }

        public List<t_clinic> GetClinicsByResearch(string search)
        {
            return utwk.ClinicRepository.GetAll().Where(s => s.name.Contains(search)).ToList();
        }



    }

    public interface IClinicService
    {
        void AddClinic(t_clinic a);

        void DeleteClinic(t_clinic a);
        t_clinic GetById(long id);
        void UpdateClinic(t_clinic a);
        List<t_clinic> getAllClinics();
        List<t_clinic> GetClinicsByResearch(string search);

    }
}
