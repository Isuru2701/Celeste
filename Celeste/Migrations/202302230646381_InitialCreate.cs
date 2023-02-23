namespace Celeste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.user_score", "enduser_id", "dbo.EndUser");
            DropForeignKey("dbo.user_entries", "enduser_id", "dbo.EndUser");
            DropForeignKey("dbo.ProfilePicture", "enduser_id", "dbo.EndUser");
            DropIndex("dbo.user_score", new[] { "enduser_id" });
            DropIndex("dbo.user_entries", new[] { "enduser_id" });
            DropIndex("dbo.ProfilePicture", new[] { "enduser_id" });
            DropTable("dbo.triggers");
            DropTable("dbo.symptoms");
            DropTable("dbo.user_score");
            DropTable("dbo.user_entries");
            DropTable("dbo.ProfilePicture");
            DropTable("dbo.EndUser");
            DropTable("dbo.comforts");
        }
    }
}
