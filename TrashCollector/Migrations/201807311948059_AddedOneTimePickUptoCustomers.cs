namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOneTimePickUptoCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "OneTimePickUp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "OneTimePickUp");
        }
    }
}
