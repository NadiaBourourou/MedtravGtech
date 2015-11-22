using Data;
using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private medtravdbContext dataContext;
        protected medtravdbContext DataContext
        {
            get
            {
                return dataContext = dbFactory.DataContext;
            }
        }

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public UnitOfWork()
        {
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }


     

        private IHotelRepository hotelRepository;
        public IHotelRepository HotelRepository
        {
            get { return hotelRepository = new HotelRepository(dbFactory); ; }
        }

        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get { return userRepository = new UserRepository(dbFactory); ; }
        }


        public void Dispose()
        {
            DataContext.Dispose();
        }
        
    }
}
