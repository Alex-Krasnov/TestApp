namespace TestApp.Models.DbModels
{
    public class ElectricityMeter
    {
        public int ElectricityMeterId { get; set; }
        public int Number { get; set; }
        public DateOnly CheckDate { get; set; }
        public int CheckPointId { get; set; }

        public CheckPoint CheckPoint { get; set; } = null!;
    }
}
