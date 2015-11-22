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
   
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);

        public void AddTestimony(t_testimony f)
        {
            utwk.TestimonyRepository.Add(f);
            utwk.Commit();
        }

        public List<t_testimony> getAllTestimonies()
        {
            return utwk.TestimonyRepository.GetAll().ToList();
        }
    }

    public interface ITestimonyService
    {
        void AddTestimony(t_testimony f);
        List<t_testimony> getAllTestimonies();
    }


}
