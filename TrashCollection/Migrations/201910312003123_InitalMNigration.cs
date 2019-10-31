namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMNigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Balance", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ZipCode", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Balance");
        }
    }
}
