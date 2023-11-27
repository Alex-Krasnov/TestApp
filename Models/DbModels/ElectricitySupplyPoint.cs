namespace TestApp.Models.DbModels
{
    public class ElectricitySupplyPoint
    {
        public int ElectricitySupplyPointId { get; set; }
        public string Name { get; set; }
        public int MaxPower { get; set; }
        public int ObjConsumptionId { get; set; }

        public ObjConsumption ObjConsumption { get; set; } = null!;
    }
}
