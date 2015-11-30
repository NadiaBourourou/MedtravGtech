namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class integration1 : DbMigration
    {
        public override void Up()
        {

            AddColumn("t_medicalrecords", "fileAnalysis", c => c.String(unicode: false));
            AddColumn("t_medicalrecords", "filePatient", c => c.String(unicode: false));
            AlterColumn("t_clinic", "address", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_clinic", "email", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_clinic", "name", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "cin", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "firstName", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "lastName", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "login", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "mail", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "password", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "arrivalDate", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "arrivalLocation", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "departureDate", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "departureLocation", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "nbSits", c => c.Int(nullable: false));
            AlterColumn("t_hotel", "address", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_hotel", "name", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_question", "questionId", c => c.Int(nullable: false, identity: true));
            AlterColumn("t_question", "description", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_question", "title", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_testimony", "testimonyId", c => c.Int(nullable: false, identity: true));
            AlterColumn("t_testimony", "description", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_testimony", "title", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
           
                }
        
        public override void Down()
        {
           
            AlterColumn("t_testimony", "title", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_testimony", "description", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_testimony", "testimonyId", c => c.Int(nullable: false));
            AlterColumn("t_question", "title", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_question", "description", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_question", "questionId", c => c.Int(nullable: false));
            AlterColumn("t_hotel", "name", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_hotel", "address", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "nbSits", c => c.Int());
            AlterColumn("t_flight", "departureLocation", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "departureDate", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "arrivalLocation", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "arrivalDate", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "password", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "mail", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "login", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "lastName", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "firstName", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_user", "cin", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_clinic", "name", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_clinic", "email", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_clinic", "address", c => c.String(maxLength: 255, storeType: "nvarchar"));
            DropColumn("t_medicalrecords", "filePatient");
            DropColumn("t_medicalrecords", "fileAnalysis");

        }
    }
}
