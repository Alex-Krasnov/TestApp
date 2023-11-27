namespace TestApp.Models.DbModels
{
    public class ObjConsumption
    {
        public int ObjConsumptionId { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }
        public int ChildOrganizationId { get; set; }

        public ChildOrganization ChildOrganization { get; set; } = null!;
        public ICollection<CheckPoint> CheckPoints { get; set; } = new List<CheckPoint>();
        public ICollection<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; } = new List<ElectricitySupplyPoint>();
    }
}
