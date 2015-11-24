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
    public class TestimonyRepository : RepositoryBase<t_testimony>, ITestimonyRepository
    {

        public TestimonyRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface ITestimonyRepository : IRepository<t_testimony>
    {

    }

}
