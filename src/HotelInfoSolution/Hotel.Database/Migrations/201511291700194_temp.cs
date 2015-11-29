namespace Hotel.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotels", "IndividualId", c => c.String());
            DropColumn("dbo.Hotels", "IdividualId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotels", "IdividualId", c => c.String());
            DropColumn("dbo.Hotels", "IndividualId");
        }
    }
}
