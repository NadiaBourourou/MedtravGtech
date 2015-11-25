namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "t_favorite",
                c => new
                {
                    favoriteId = c.Int(nullable: false),
                    nameFavorite = c.String(maxLength: 255, storeType: "nvarchar"),
                    patient_userId = c.Int(),
                })
                .PrimaryKey(t => t.favoriteId);
              //  .ForeignKey("t_user", t => t.patient_userId)
              //  .Index(t => t.patient_userId);
            
 
            AddForeignKey("t_favorite", "patient_userId", "dbo.t_user", "favoriteId");

            CreateTable(
                "t_tip",
                c => new
                {
                    tipId = c.Int(nullable: false),
                    title = c.String(maxLength: 255, storeType: "nvarchar"),
                    body = c.String(maxLength: 255, storeType: "nvarchar"),
                    liked = c.Int(nullable: false),
                    disliked = c.Int(nullable: false),
                    idPatientVoted = c.Int(nullable: false),
                    administrator_userId = c.Int(),
                })
                .PrimaryKey(t => t.tipId);
              //  .ForeignKey("t_user", t => t.administrator_userId)
              // .Index(t => t.administrator_userId);
            AddForeignKey("t_tip", "administrator_userId", "dbo.t_user", "tipId");

            CreateTable(
                "dbo.t_tipFavorite",
                c => new
                    {
                        t_favorite = c.Int(nullable: false),
                        t_tip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.t_favorite, t.t_tip })
                .ForeignKey("t_favorite", t => t.t_favorite, cascadeDelete: true)
                .ForeignKey("t_tip", t => t.t_tip, cascadeDelete: true)
                .Index(t => t.t_favorite)
                .Index(t => t.t_tip);
            
            AlterColumn("t_flight", "arrivalDate", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "arrivalLocation", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "departureDate", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "departureLocation", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "nbSits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_tipFavorite", "t_tip", "t_tip");
            DropForeignKey("dbo.t_tipFavorite", "t_favorite", "t_favorite");
            DropForeignKey("t_tip", "administrator_userId", "t_user");
            DropForeignKey("t_favorite", "patient_userId", "t_user");
            DropIndex("dbo.t_tipFavorite", new[] { "t_tip" });
            DropIndex("dbo.t_tipFavorite", new[] { "t_favorite" });
            DropIndex("t_tip", new[] { "administrator_userId" });
            DropIndex("t_favorite", new[] { "patient_userId" });
            AlterColumn("t_flight", "nbSits", c => c.Int());
            AlterColumn("t_flight", "departureLocation", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "departureDate", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "arrivalLocation", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("t_flight", "arrivalDate", c => c.String(maxLength: 255, storeType: "nvarchar"));
            DropTable("dbo.t_tipFavorite");
            DropTable("t_tip");
            DropTable("t_favorite");
        }
    }
}
