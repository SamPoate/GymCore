namespace GymCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkoutsMakePublic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkoutsModels", "MakePublic", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkoutsModels", "MakePublic");
        }
    }
}
