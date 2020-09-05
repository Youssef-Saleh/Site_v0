namespace WebsiteBEAT_v0.Migrations.SiteMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Uninitializedlistsfixattempt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "Section_SectionID", "dbo.Sections");
            DropIndex("dbo.Members", new[] { "Section_SectionID" });
            CreateTable(
                "dbo.SectionMembers",
                c => new
                    {
                        Section_SectionID = c.Int(nullable: false),
                        Member_MemberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Section_SectionID, t.Member_MemberID })
                .ForeignKey("dbo.Sections", t => t.Section_SectionID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Member_MemberID, cascadeDelete: true)
                .Index(t => t.Section_SectionID)
                .Index(t => t.Member_MemberID);
            
            DropColumn("dbo.Members", "Section_SectionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Section_SectionID", c => c.Int());
            DropForeignKey("dbo.SectionMembers", "Member_MemberID", "dbo.Members");
            DropForeignKey("dbo.SectionMembers", "Section_SectionID", "dbo.Sections");
            DropIndex("dbo.SectionMembers", new[] { "Member_MemberID" });
            DropIndex("dbo.SectionMembers", new[] { "Section_SectionID" });
            DropTable("dbo.SectionMembers");
            CreateIndex("dbo.Members", "Section_SectionID");
            AddForeignKey("dbo.Members", "Section_SectionID", "dbo.Sections", "SectionID");
        }
    }
}
