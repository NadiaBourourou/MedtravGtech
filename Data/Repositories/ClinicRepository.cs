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
  public  class ClinicRepository : RepositoryBase<t_clinic>, IClinicRepository
    {
        public ClinicRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
    public interface IClinicRepository : IRepository<t_clinic>
    {

    }
}
