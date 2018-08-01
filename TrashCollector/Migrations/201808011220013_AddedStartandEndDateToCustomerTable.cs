namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStartandEndDateToCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StartDate", c => c.String());
            AddColumn("dbo.Customers", "EndDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "EndDate");
            DropColumn("dbo.Customers", "StartDate");
        }
    }
}
