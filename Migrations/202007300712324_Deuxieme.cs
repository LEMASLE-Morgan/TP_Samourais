namespace TP_Samouraï.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deuxieme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Armes", "Id", "dbo.Samourais");
            DropIndex("dbo.Armes", new[] { "Id" });
            DropPrimaryKey("dbo.Armes");
            AddColumn("dbo.Samourais", "Arme_Id", c => c.Int());
            AddColumn("dbo.Samourais", "ArtMartial_Id", c => c.Int());
            AlterColumn("dbo.Armes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Armes", "Id");
            CreateIndex("dbo.Samourais", "Arme_Id");
            CreateIndex("dbo.Samourais", "ArtMartial_Id");
            AddForeignKey("dbo.Samourais", "ArtMartial_Id", "dbo.ArtMartials", "Id");
            AddForeignKey("dbo.Samourais", "Arme_Id", "dbo.Armes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samourais", "Arme_Id", "dbo.Armes");
            DropForeignKey("dbo.Samourais", "ArtMartial_Id", "dbo.ArtMartials");
            DropIndex("dbo.Samourais", new[] { "ArtMartial_Id" });
            DropIndex("dbo.Samourais", new[] { "Arme_Id" });
            DropPrimaryKey("dbo.Armes");
            AlterColumn("dbo.Armes", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Samourais", "ArtMartial_Id");
            DropColumn("dbo.Samourais", "Arme_Id");
            AddPrimaryKey("dbo.Armes", "Id");
            CreateIndex("dbo.Armes", "Id");
            AddForeignKey("dbo.Armes", "Id", "dbo.Samourais", "Id");
        }
    }
}
