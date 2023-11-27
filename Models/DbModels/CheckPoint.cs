namespace TestApp.Models.DbModels
{
    public class CheckPoint
    {
        public int CheckPointId { get; set; }
        public string Name { get; set; }
        public int ObjConsumptionId { get; set; }

        public ObjConsumption ObjConsumption { get; set; } = null!;

        public ElectricityMeter? ElectricityMeter { get; set; }
        public CurrentTransformer? CurrentTransformer { get; set; }
        public VoltageTransformer? VoltageTransformer { get; set; }

        public ICollection<CalculationDevice> Device { get; set; } = new List<CalculationDevice>();
    }
}
