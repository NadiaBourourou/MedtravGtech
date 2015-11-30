using Data.Infrastructure;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
 
    public class SurgeryBookingRepository : RepositoryBase<t_surgerypatient>, ISurgeryBookingRepository
    {
        public SurgeryBookingRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }

    }
    public interface ISurgeryBookingRepository : IRepository<t_surgerypatient>
    {

    }
}
