namespace TestApp.Models.DbModels
{
    public class CurrentTransformer
    {
        public int CurrentTransformerId { get; set; }
        public int Number { get; set; }
        public string CurrentTransformerType { get; set; }
        public DateOnly CheckDate { get; set; }
        public int TransformationCoefficient { get; set; }
        public int CheckPointId { get; set; }

        public CheckPoint CheckPoint { get; set; } = null!;
    }
}
