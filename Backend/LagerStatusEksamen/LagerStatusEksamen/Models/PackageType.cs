namespace LagerStatusEksamen.Models
{
    public class PackageType
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public PackageType() { Name = ""; Description = ""; }
        public PackageType(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
