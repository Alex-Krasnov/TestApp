namespace TestApp.Models.DbModels
{
    public class ChildOrganization
    {
        public int ChildOrganizationId { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }
        public int OrganizationId { get; set; }

        public Organization Organization { get; set; } = null!;
        public ICollection<ObjConsumption> ObjConsumptions { get; set; } = new List<ObjConsumption>();
    }
}
