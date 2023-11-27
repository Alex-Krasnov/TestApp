namespace TestApp.Models.DbModels
{
    public class CalculationDevice
    {
        public int CalculationDeviceId { get; set; }
        public string Name { get; set; }
        public DateOnly Date {  get; set; }
        public ICollection<CheckPoint> Point { get; set; } = new List<CheckPoint>();
    }
}