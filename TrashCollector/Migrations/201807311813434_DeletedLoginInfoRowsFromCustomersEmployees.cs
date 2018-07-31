namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedLoginInfoRowsFromCustomersEmployees : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "UserName");
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Employees", "UserName");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Employees", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Email", c => c.String());
            AddColumn("dbo.Employees", "Password", c => c.String());
            AddColumn("dbo.Employees", "UserName", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Customers", "Password", c => c.String());
            AddColumn("dbo.Customers", "UserName", c => c.String());
        }
    }
}
