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


        private IFlightRepository flightRepository;
        public IFlightRepository FlightRepository
        {
            get { return flightRepository = new FlightRepository(dbFactory); ; }
        }

        private IFlightMatchingRepository flightMatchingRepository;
        public IFlightMatchingRepository FlightMatchingRepository
        {
            get { return flightMatchingRepository = new FlightMatchingRepository(dbFactory); ; }
        }

        private ITestimonyRepository testimonyRepository;
        public ITestimonyRepository TestimonyRepository
        {
            get { return testimonyRepository = new TestimonyRepository(dbFactory); ; }
        }

        private IFavoriteRepository favoriteRepository;
        public IFavoriteRepository FavoriteRepository
        {
            get { return favoriteRepository = new FavoriteRepository(dbFactory); ; }
        }

        private ITipRepository tipRepository;
        public ITipRepository TipRepository
        {
            get { return tipRepository = new TipRepository(dbFactory); ; }

        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
        
    }
}
