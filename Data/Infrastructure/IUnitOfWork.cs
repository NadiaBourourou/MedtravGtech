﻿using  Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();


        IHotelRepository HotelRepository { get; }

        IUserRepository UserRepository { get; }

        IFlightRepository FlightRepository { get; }

        IFlightMatchingRepository FlightMatchingRepository { get; }

        ITestimonyRepository TestimonyRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        ITipRepository TipRepository { get; }

        IServiceHotelRepository ServiceHotelRepository { get; }
        IHotelBookingRepository HotelBookingRepository { get; }
        IClinicBookingRepository ClinicBookingRepository { get; }


    }
}
