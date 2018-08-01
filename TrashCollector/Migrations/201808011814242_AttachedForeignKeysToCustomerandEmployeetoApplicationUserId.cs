namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttachedForeignKeysToCustomerandEmployeetoApplicationUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "Id");
            CreateIndex("dbo.Employees", "Id");
            AddForeignKey("dbo.Customers", "Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "Id" });
            DropIndex("dbo.Customers", new[] { "Id" });
            DropColumn("dbo.Employees", "Id");
            DropColumn("dbo.Customers", "Id");
        }
    }
}
