namespace PrjDay3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCar",
                c => new
                    {
                        CarNo = c.Int(nullable: false, identity: true),
                        CarName = c.String(),
                        CarType = c.String(),
                    })
                .PrimaryKey(t => t.CarNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblCar");
        }
    }
}
