namespace MaerskLineAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addschedules : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        ContainerName = c.Int(nullable: false),
                        ContainerDescription = c.String(nullable: false),
                        ContainerWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        ShipID = c.Int(nullable: false),
                        ContainerID = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        DepartureShipyardID = c.Int(nullable: false),
                        ArrivalShipyardID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.Containers", t => t.ContainerID, cascadeDelete: false)
                .ForeignKey("dbo.Ships", t => t.ShipID, cascadeDelete: false)
                .ForeignKey("dbo.Shipyards", t => t.DepartureShipyardID, cascadeDelete: false)
                .ForeignKey("dbo.Shipyards", t => t.ArrivalShipyardID, cascadeDelete: false)
                .Index(t => t.ShipID)
                .Index(t => t.ContainerID)
                .Index(t => t.DepartureShipyardID)
                .Index(t => t.ArrivalShipyardID);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        ShipName = c.String(nullable: false),
                        ShipType = c.String(),
                        TotalContainers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipID);
            
            CreateTable(
                "dbo.Shipyards",
                c => new
                    {
                        ShipyardID = c.Int(nullable: false, identity: true),
                        ShipyardName = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.ShipyardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ArrivalShipyardID", "dbo.Shipyards");
            DropForeignKey("dbo.Reservations", "DepartureShipyardID", "dbo.Shipyards");
            DropForeignKey("dbo.Reservations", "ShipID", "dbo.Ships");
            DropForeignKey("dbo.Reservations", "ContainerID", "dbo.Containers");
            DropIndex("dbo.Reservations", new[] { "ArrivalShipyardID" });
            DropIndex("dbo.Reservations", new[] { "DepartureShipyardID" });
            DropIndex("dbo.Reservations", new[] { "ContainerID" });
            DropIndex("dbo.Reservations", new[] { "ShipID" });
            DropTable("dbo.Shipyards");
            DropTable("dbo.Ships");
            DropTable("dbo.Reservations");
            DropTable("dbo.Containers");
        }
    }
}
