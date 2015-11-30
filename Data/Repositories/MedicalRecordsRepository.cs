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
    public class MedicalRecordsRepository : RepositoryBase<t_medicalrecords>, IMedicalRecordsRepository
    {
        public MedicalRecordsRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface IMedicalRecordsRepository : IRepository<t_medicalrecords>
    {

    }
}
