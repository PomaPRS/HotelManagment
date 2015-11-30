namespace Hotel.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "IndividualId", c => c.String());
            DropColumn("dbo.Workers", "IdividualId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "IdividualId", c => c.String());
            DropColumn("dbo.Workers", "IndividualId");
        }
    }
}
