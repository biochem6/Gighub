namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Followers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Follows", "ArtistId", "dbo.Gigs");
            DropIndex("dbo.Follows", new[] { "ArtistId" });
            DropPrimaryKey("dbo.Follows");
            AddColumn("dbo.Follows", "Artist_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Follows", "ArtistId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Follows", new[] { "ArtistId", "FollowerId" });
            CreateIndex("dbo.Follows", "Artist_Id");
            AddForeignKey("dbo.Follows", "Artist_Id", "dbo.Gigs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "Artist_Id", "dbo.Gigs");
            DropIndex("dbo.Follows", new[] { "Artist_Id" });
            DropPrimaryKey("dbo.Follows");
            AlterColumn("dbo.Follows", "ArtistId", c => c.Int(nullable: false));
            DropColumn("dbo.Follows", "Artist_Id");
            AddPrimaryKey("dbo.Follows", new[] { "ArtistId", "FollowerId" });
            CreateIndex("dbo.Follows", "ArtistId");
            AddForeignKey("dbo.Follows", "ArtistId", "dbo.Gigs", "Id");
        }
    }
}
