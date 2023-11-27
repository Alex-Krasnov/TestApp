using Microsoft.EntityFrameworkCore;
using System.Drawing;
using TestApp.Models.DbModels;
using TestApp.Models.InputModels;

namespace TestApp.Data
{
    public class TestAppContext : DbContext
    {
        public DbSet<CheckPoint> CheckPoints { get; set; }
        public DbSet<ChildOrganization> ChildOrganizations { get; set; }
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; }
        public DbSet<ElectricityMeter> ElectricityMeters { get; set; }
        public DbSet<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }
        public DbSet<ObjConsumption> ObjConsumptions { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; }
        public DbSet<CalculationDevice> CalculationDevices { get; set; }

        public TestAppContext()
        {
        }

        public TestAppContext(DbContextOptions<TestAppContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var host = "localhost";
            var port = "5432";
            var connectionString = $"Host={host};Port={port};Database=TestApp;Username=vs_test;Password=4100";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().HasData(
                    new Organization { OrganizationId = 1, Name = "Organization1", Addres = "Street1" },
                    new Organization { OrganizationId = 2, Name = "Organization2", Addres = "Street2" }
            );

            modelBuilder.Entity<ChildOrganization>().HasData(
                    new ChildOrganization { ChildOrganizationId = 1, Name = "ChildOrganization1", Addres = "Street1", OrganizationId = 1 },
                    new ChildOrganization { ChildOrganizationId = 2, Name = "ChildOrganization2", Addres = "Street2", OrganizationId = 1 },
                    new ChildOrganization { ChildOrganizationId = 3, Name = "ChildOrganization3", Addres = "Street3", OrganizationId = 2 }
            );

            modelBuilder.Entity<ObjConsumption>().HasData(
                    new ObjConsumption { ObjConsumptionId = 1, Name = "ObjConsumption1", Addres = "Street1", ChildOrganizationId = 1 },
                    new ObjConsumption { ObjConsumptionId = 2, Name = "ObjConsumption2", Addres = "Street2", ChildOrganizationId = 2 },
                    new ObjConsumption { ObjConsumptionId = 3, Name = "ObjConsumption3", Addres = "Street3", ChildOrganizationId = 3 },
                    new ObjConsumption { ObjConsumptionId = 4, Name = "ObjConsumption4", Addres = "Street4", ChildOrganizationId = 3 }
            );

            modelBuilder.Entity<CheckPoint>().HasData(
                    new CheckPoint { CheckPointId = 1, Name = "CheckPoint1", ObjConsumptionId = 1 },
                    new CheckPoint { CheckPointId = 2, Name = "CheckPoint2", ObjConsumptionId = 1 },
                    new CheckPoint { CheckPointId = 3, Name = "CheckPoint3", ObjConsumptionId = 2 },
                    new CheckPoint { CheckPointId = 4, Name = "CheckPoint4", ObjConsumptionId = 3 },
                    new CheckPoint { CheckPointId = 5, Name = "CheckPoint5", ObjConsumptionId = 3 }
            );

            modelBuilder.Entity<ElectricityMeter>().HasData(
                    new ElectricityMeter { ElectricityMeterId = 1, Number = 1, CheckDate = new DateOnly(1900, 1, 1), CheckPointId = 1 },
                    new ElectricityMeter { ElectricityMeterId = 2, Number = 2, CheckDate = new DateOnly(1900, 1, 1), CheckPointId = 2 },
                    new ElectricityMeter { ElectricityMeterId = 3, Number = 3, CheckDate = DateOnly.FromDateTime(DateTime.Now), CheckPointId = 3 },
                    new ElectricityMeter { ElectricityMeterId = 4, Number = 4, CheckDate = DateOnly.FromDateTime(DateTime.Now), CheckPointId = 4 },
                    new ElectricityMeter { ElectricityMeterId = 5, Number = 5, CheckDate = DateOnly.FromDateTime(DateTime.Now), CheckPointId = 5 }
            );

            modelBuilder.Entity<CurrentTransformer>().HasData(
                    new CurrentTransformer { CurrentTransformerId = 1, Number = 1, CurrentTransformerType = "Type1", CheckDate = new DateOnly(1900, 1, 1), CheckPointId = 1 },
                    new CurrentTransformer { CurrentTransformerId = 2, Number = 2, CurrentTransformerType = "Type2", CheckDate = new DateOnly(1900, 1, 1), CheckPointId = 2 },
                    new CurrentTransformer { CurrentTransformerId = 3, Number = 3, CurrentTransformerType = "Type3", CheckDate = DateOnly.FromDateTime(DateTime.Now), CheckPointId = 3 },
                    new CurrentTransformer { CurrentTransformerId = 4, Number = 4, CurrentTransformerType = "Type4", CheckDate = DateOnly.FromDateTime(DateTime.Now), CheckPointId = 4 },
                    new CurrentTransformer { CurrentTransformerId = 5, Number = 5, CurrentTransformerType = "Type3", CheckDate = DateOnly.FromDateTime(DateTime.Now), CheckPointId = 5 }
            );

            modelBuilder.Entity<VoltageTransformer>().HasData(
                    new VoltageTransformer { VoltageTransformerId = 1, Number = 1, VoltageTransformerType = "Type1", CheckDate = new DateOnly(1900, 1, 1), CheckPointId = 1 },
                    new VoltageTransformer { VoltageTransformerId = 2, Number = 2, VoltageTransformerType = "Type2", CheckDate = new DateOnly(1900, 1, 1), CheckPointId = 2 },
                    new VoltageTransformer { VoltageTransformerId = 3, Number = 3, VoltageTransformerType = "Type3", CheckDate = DateOnly.FromDateTime(DateTime.Now), CheckPointId = 3 },
                    new VoltageTransformer { VoltageTransformerId = 4, Number = 4, VoltageTransformerType = "Type4", CheckDate = DateOnly.FromDateTime(DateTime.Now), CheckPointId = 4 },
                    new VoltageTransformer { VoltageTransformerId = 5, Number = 5, VoltageTransformerType = "Type3", CheckDate = DateOnly.FromDateTime(DateTime.Now), CheckPointId = 5 }
            );

            modelBuilder.Entity<ElectricitySupplyPoint>().HasData(
                    new ElectricitySupplyPoint { ElectricitySupplyPointId = 1, Name = "ElectricitySupplyPoint1", MaxPower = 1, ObjConsumptionId = 1 },
                    new ElectricitySupplyPoint { ElectricitySupplyPointId = 2, Name = "ElectricitySupplyPoint2", MaxPower = 2, ObjConsumptionId = 1 },
                    new ElectricitySupplyPoint { ElectricitySupplyPointId = 3, Name = "ElectricitySupplyPoint3", MaxPower = 3, ObjConsumptionId = 2 },
                    new ElectricitySupplyPoint { ElectricitySupplyPointId = 4, Name = "ElectricitySupplyPoint4", MaxPower = 4, ObjConsumptionId = 3 },
                    new ElectricitySupplyPoint { ElectricitySupplyPointId = 5, Name = "ElectricitySupplyPoint5", MaxPower = 3, ObjConsumptionId = 4 }
            );

            modelBuilder.Entity<CalculationDevice>().HasData(
                    new CalculationDevice { CalculationDeviceId = 1, Name = "CalculationDevice1", Date = new DateOnly(2018, 1, 1)},
                    new CalculationDevice { CalculationDeviceId = 2, Name = "CalculationDevice2", Date = DateOnly.FromDateTime(DateTime.Now)}
            );
        }
    }
}
