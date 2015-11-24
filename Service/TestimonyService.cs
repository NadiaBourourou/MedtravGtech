using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.Infrastructure;

namespace Service
{
    // test testimony
    public class TestimonyService : ITestimonyService
    {
   
        static public DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;

        public TestimonyService()
        {
             dbFactory = new DatabaseFactory();
             utwk = new UnitOfWork(dbFactory);
        }
        public void AddTestimony(t_testimony f)
        {
            utwk.TestimonyRepository.Add(f);
            utwk.Commit();
        }

        public List<t_testimony> getAllTestimonies()
        {
            return utwk.TestimonyRepository.GetAll().ToList();
        }

        public void DeleteTestimony(t_testimony a)
        {

            utwk.TestimonyRepository.Delete(a);
            utwk.Commit();
        }
        public void UpdateTestimony(t_testimony a)
        {
           
            utwk.TestimonyRepository.Update(a);
            utwk.Commit();

        }

        public t_testimony GetById(long id)
        {
            
            return utwk.TestimonyRepository.GetById(id);
        }

    }

    public interface ITestimonyService
    {
        void AddTestimony(t_testimony f);
        List<t_testimony> getAllTestimonies();
        void DeleteTestimony(t_testimony a);
        void UpdateTestimony(t_testimony a);
        t_testimony GetById(long id);
    }


}
