using TestApp.Models.DbModels;

namespace TestApp.Models.InputModels
{
    public class NewCheckPointPlus
    {
        public NewCheckPoint CheckPoint { get; set; } = null!;
        public NewElectricityMeter? ElectricityMeter { get; set; }
        public NewCurrentTransformer? CurrentTransformer { get; set; }
        public NewVoltageTransformer? VoltageTransformer { get; set; }
    }

    public class NewCheckPoint
    {
        public int CheckPointId { get; set; }
        public string Name { get; set; }
        public int ObjConsumptionId { get; set; }
    }

    public class NewElectricityMeter
    {
        public int ElectricityMeterId { get; set; }
        public int Number { get; set; }
        public DateOnly CheckDate { get; set; }
        public int CheckPointId { get; set; }
    }

    public class NewCurrentTransformer
    {
        public int CurrentTransformerId { get; set; }
        public int Number { get; set; }
        public string CurrentTransformerType { get; set; }
        public DateOnly CheckDate { get; set; }
        public int TransformationCoefficient { get; set; }
        public int CheckPointId { get; set; }

    }

    public class NewVoltageTransformer
    {
        public int VoltageTransformerId { get; set; }
        public int Number { get; set; }
        public string VoltageTransformerType { get; set; }
        public DateOnly CheckDate { get; set; }
        public int TransformationCoefficient { get; set; }
        public int CheckPointId { get; set; }
    }
}
