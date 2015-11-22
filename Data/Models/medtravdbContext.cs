using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Models.Mapping;

namespace Data.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class medtravdbContext : DbContext
    {
        static medtravdbContext()
        {
            Database.SetInitializer<medtravdbContext>(null);
        }

        public medtravdbContext()
            : base("Name=medtravdbContext")
        {

            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 1 * 60;
        }

        public DbSet<t_booking> t_booking { get; set; }
        public DbSet<t_clinic> t_clinic { get; set; }
        public DbSet<t_clinicbooking> t_clinicbooking { get; set; }
        public DbSet<t_doctorpatient> t_doctorpatient { get; set; }
        public DbSet<t_flight> t_flight { get; set; }
        public DbSet<t_flightmatching> t_flightmatching { get; set; }
        public DbSet<t_hotel> t_hotel { get; set; }
        public DbSet<t_hotelbooking> t_hotelbooking { get; set; }
        public DbSet<t_medicalrecords> t_medicalrecords { get; set; }
        public DbSet<t_procedure> t_procedure { get; set; }
        public DbSet<t_question> t_question { get; set; }
        public DbSet<t_servicehotel> t_servicehotel { get; set; }
        public DbSet<t_surgery> t_surgery { get; set; }
        public DbSet<t_surgerypatient> t_surgerypatient { get; set; }
        public DbSet<t_testimony> t_testimony { get; set; }
        public DbSet<t_user> t_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new t_bookingMap());
            modelBuilder.Configurations.Add(new t_clinicMap());
            modelBuilder.Configurations.Add(new t_clinicbookingMap());
            modelBuilder.Configurations.Add(new t_doctorpatientMap());
            modelBuilder.Configurations.Add(new t_flightMap());
            modelBuilder.Configurations.Add(new t_flightmatchingMap());
            modelBuilder.Configurations.Add(new t_hotelMap());
            modelBuilder.Configurations.Add(new t_hotelbookingMap());
            modelBuilder.Configurations.Add(new t_medicalrecordsMap());
            modelBuilder.Configurations.Add(new t_procedureMap());
            modelBuilder.Configurations.Add(new t_questionMap());
            modelBuilder.Configurations.Add(new t_servicehotelMap());
            modelBuilder.Configurations.Add(new t_surgeryMap());
            modelBuilder.Configurations.Add(new t_surgerypatientMap());
            modelBuilder.Configurations.Add(new t_testimonyMap());
            modelBuilder.Configurations.Add(new t_userMap());
        }
    }
}
