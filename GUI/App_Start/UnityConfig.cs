using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Service;
using Data.Interfaces;
using Data.Infrastructure;
using Data.Repositories;
using GUI.Controllers;

namespace GUI.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            container.RegisterType<IFlightService, FlightService>(new PerRequestLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IFlightRepository, FlightRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IFlightMatchingRepository, FlightMatchingRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new PerRequestLifetimeManager());
            container.RegisterType<ITestimonyService, TestimonyService>(new PerRequestLifetimeManager());
            container.RegisterType<ITestimonyRepository, TestimonyRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IQuestionService, QuestionService>(new PerRequestLifetimeManager());
            container.RegisterType<IQuestionRepository, QuestionRepository>(new PerRequestLifetimeManager());

            container.RegisterType<ITipService, TipService>(new PerRequestLifetimeManager());
            container.RegisterType<IFlightMatchingService, FlightMatchingService>(new PerRequestLifetimeManager());

            container.RegisterType<IUserRepository, UserRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IUserService, UserService>(new PerRequestLifetimeManager());



            container.RegisterType<IHotelRepository, HotelRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IHotelService, HotelService>(new PerRequestLifetimeManager());


            container.RegisterType<IHotelBookingRepository, HotelBookingRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IHotelBookingService, HotelBookingService>(new PerRequestLifetimeManager());

            container.RegisterType<IClinicBookingRepository, ClinicBookingRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IClinicBookingService, ClinicBookingService>(new PerRequestLifetimeManager());
            container.RegisterType<IClinicRepository, ClinicRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IClinicService, ClinicService>(new PerRequestLifetimeManager());

            container.RegisterType<IServiceHotelRepository, ServiceHotelRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IServiceHotelService, ServiceHotelService>(new PerRequestLifetimeManager());

            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new PerRequestLifetimeManager());

            container.RegisterType<IDoctorPatientRepository, DoctorPatientRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IDoctorPatientService, DoctorPatientService>(new PerRequestLifetimeManager());

            container.RegisterType<ISurgeryBookingRepository, SurgeryBookingRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ISurgeryBookingService, SurgeryBookingService>(new PerRequestLifetimeManager());

            container.RegisterType<ISurgeryRepository, SurgeryRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ISurgeryService, SurgeryService>(new PerRequestLifetimeManager());

            container.RegisterType<IMedicalRecordsRepository, MedicalRecordsRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IMedicalRecordsService, MedicalRecordsService>(new PerRequestLifetimeManager());


            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());


        }
    }
}
