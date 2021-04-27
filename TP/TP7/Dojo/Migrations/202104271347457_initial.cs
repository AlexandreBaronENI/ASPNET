namespace Dojo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Armes", newName: "Arme");
            RenameTable(name: "dbo.ArtMartials", newName: "ArtMartial");
            RenameTable(name: "dbo.Samourais", newName: "Samourai");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Samourai", newName: "Samourais");
            RenameTable(name: "dbo.ArtMartial", newName: "ArtMartials");
            RenameTable(name: "dbo.Arme", newName: "Armes");
        }
    }
}
