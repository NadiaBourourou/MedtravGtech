namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("t_clinic", "ImgName", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("t_clinic", "ImgName");
        }
    }
}
