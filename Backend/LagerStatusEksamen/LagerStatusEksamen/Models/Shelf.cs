namespace LagerStatusEksamen.Models
{
    public class Shelf
    {
        public bool IsStocked { get; set; }
        public string MAC { get; set; }
        public string? PackageTypeName { get; set; }
        public int ID { get; set; }

        public Shelf() { MAC = ""; }
        public Shelf(string mac, string? packageTypeName, bool isStocked, int id)
        {
            PackageTypeName = packageTypeName;
            IsStocked = isStocked;
            MAC = mac;
            ID = id;
        }
        public Shelf(string mac, string? packageTypeName, bool isStocked)
            : this(mac, packageTypeName, isStocked, 0) { }
    }
}
