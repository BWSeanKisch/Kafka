namespace Kafka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.String(),
                        Title = c.String(),
                        Preamble = c.String(),
                        Image = c.String(),
                        Date = c.DateTime(nullable: false),
                        Category = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostModels");
        }
    }
}
