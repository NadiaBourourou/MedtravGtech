namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            // AddColumn("t_user", "ImgName", c => c.String(unicode: false));
           //DropColumn("t_user", "ImageName");
        }
        
        public override void Down()
        {
            AddColumn("t_user", "ImageName", c => c.String(unicode: false));
            DropColumn("t_user", "ImgName");
        }
    }
}
