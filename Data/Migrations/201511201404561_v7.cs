namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("t_hotel", "ImgName", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("t_hotel", "ImgName");
        }
    }
}
