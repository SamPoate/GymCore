namespace GymCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkoutsModels", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkoutsModels", "UserName");
        }
    }
}
