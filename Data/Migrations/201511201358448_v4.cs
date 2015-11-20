namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
         //   DropColumn("t_clinic", "ImageName");
         //   DropColumn("t_hotel", "ImageName");
        }
        
        public override void Down()
        {
            AddColumn("t_hotel", "ImageName", c => c.String(unicode: false));
            AddColumn("t_clinic", "ImageName", c => c.String(unicode: false));
        }
    }
}
