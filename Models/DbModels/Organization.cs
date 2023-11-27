namespace TestApp.Models.DbModels
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }

        public ICollection<ChildOrganization> ChildOrganizations { get; set; } = new List<ChildOrganization>();
    }
}
