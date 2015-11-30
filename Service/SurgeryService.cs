using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public class SurgeryService: ISurgeryService
    {

        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);



        public IEnumerable<t_surgery> GetSurgeries()
        {

            return utwk.SurgeryRepository.GetAll();
        }

        public List<t_surgery> GetSurgeriesByResearch(string search)
        {
            return utwk.SurgeryRepository.GetAll().Where(s => s.name.Contains(search)).ToList();
        }
    }

        public interface ISurgeryService
        {

        IEnumerable<t_surgery> GetSurgeries();
        List<t_surgery> GetSurgeriesByResearch(string search);

    }

    
    
}
