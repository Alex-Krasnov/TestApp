namespace TestApp.Models.DbModels
{
    public class VoltageTransformer
    {
        public int VoltageTransformerId { get; set; }
        public int Number { get; set; }
        public string VoltageTransformerType { get; set; }
        public DateOnly CheckDate { get; set; }
        public int TransformationCoefficient { get; set; }
        public int CheckPointId { get; set; }

        public CheckPoint CheckPoint { get; set; } = null!;
    }
}
