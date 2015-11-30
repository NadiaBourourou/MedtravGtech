using Data.Infrastructure;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class SurgeryRepository : RepositoryBase<t_surgery>, ISurgeryRepository
    {
        public SurgeryRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }

    }
    public interface ISurgeryRepository : IRepository<t_surgery>
    {

    }
}
