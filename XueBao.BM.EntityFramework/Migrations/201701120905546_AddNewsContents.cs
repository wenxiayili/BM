namespace XueBao.BM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewsContents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "XueBao.NewsComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false, maxLength: 36),
                        CreateTime = c.DateTime(nullable: false),
                        Content = c.String(nullable: false, maxLength: 255),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        News_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.News_Id)
                .Index(t => t.News_Id);
            
            AddColumn("dbo.NewsCategories", "NewID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("XueBao.NewsComments", "News_Id", "dbo.News");
            DropIndex("XueBao.NewsComments", new[] { "News_Id" });
            DropColumn("dbo.NewsCategories", "NewID");
            DropTable("XueBao.NewsComments");
        }
    }
}
