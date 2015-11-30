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
   public class ClinicBookingRepository : RepositoryBase<t_clinicbooking>, IClinicBookingRepository
    {
        public ClinicBookingRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
    public interface IClinicBookingRepository : IRepository<t_clinicbooking>
    {

    }
}
