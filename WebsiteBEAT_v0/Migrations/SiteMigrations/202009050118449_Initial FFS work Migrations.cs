namespace WebsiteBEAT_v0.Migrations.SiteMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialFFSworkMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StartDate = c.DateTime(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Phone = c.String(),
                        College = c.String(),
                        Faculty = c.String(),
                        Department = c.String(),
                        Fname = c.String(),
                        Mname = c.String(),
                        Lname = c.String(),
                        Position = c.String(),
                        BirthDate = c.DateTime(),
                        Task_TaskID = c.Int(),
                        Section_SectionID = c.Int(),
                    })
                .PrimaryKey(t => t.MemberID)
                .ForeignKey("dbo.Tasks", t => t.Task_TaskID)
                .ForeignKey("dbo.Sections", t => t.Section_SectionID)
                .Index(t => t.Task_TaskID)
                .Index(t => t.Section_SectionID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Name = c.String(),
                        Description = c.String(),
                        TaskAppointer_MemberID = c.Int(),
                        Member_MemberID = c.Int(),
                        Member_MemberID1 = c.Int(),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Members", t => t.TaskAppointer_MemberID)
                .ForeignKey("dbo.Members", t => t.Member_MemberID)
                .ForeignKey("dbo.Members", t => t.Member_MemberID1)
                .Index(t => t.TaskAppointer_MemberID)
                .Index(t => t.Member_MemberID)
                .Index(t => t.Member_MemberID1);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionID = c.Int(nullable: false, identity: true),
                        SectionName = c.String(),
                        Supervisor = c.String(),
                    })
                .PrimaryKey(t => t.SectionID);
            
            CreateTable(
                "dbo.MemberEvents",
                c => new
                    {
                        Member_MemberID = c.Int(nullable: false),
                        Event_EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_MemberID, t.Event_EventID })
                .ForeignKey("dbo.Members", t => t.Member_MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_EventID, cascadeDelete: true)
                .Index(t => t.Member_MemberID)
                .Index(t => t.Event_EventID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "Section_SectionID", "dbo.Sections");
            DropForeignKey("dbo.Tasks", "Member_MemberID1", "dbo.Members");
            DropForeignKey("dbo.Tasks", "Member_MemberID", "dbo.Members");
            DropForeignKey("dbo.Tasks", "TaskAppointer_MemberID", "dbo.Members");
            DropForeignKey("dbo.Members", "Task_TaskID", "dbo.Tasks");
            DropForeignKey("dbo.MemberEvents", "Event_EventID", "dbo.Events");
            DropForeignKey("dbo.MemberEvents", "Member_MemberID", "dbo.Members");
            DropIndex("dbo.MemberEvents", new[] { "Event_EventID" });
            DropIndex("dbo.MemberEvents", new[] { "Member_MemberID" });
            DropIndex("dbo.Tasks", new[] { "Member_MemberID1" });
            DropIndex("dbo.Tasks", new[] { "Member_MemberID" });
            DropIndex("dbo.Tasks", new[] { "TaskAppointer_MemberID" });
            DropIndex("dbo.Members", new[] { "Section_SectionID" });
            DropIndex("dbo.Members", new[] { "Task_TaskID" });
            DropTable("dbo.MemberEvents");
            DropTable("dbo.Sections");
            DropTable("dbo.Tasks");
            DropTable("dbo.Members");
            DropTable("dbo.Events");
        }
    }
}
