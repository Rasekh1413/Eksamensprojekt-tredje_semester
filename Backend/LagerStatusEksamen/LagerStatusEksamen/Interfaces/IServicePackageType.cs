using LagerStatusEksamen.Models;

namespace LagerStatusEksamen.Interfaces
{
    public interface IServicePackageType
    {
        public List<PackageType> GetAll();
        public PackageType? GetByName(string name);
        public PackageType Add(string name, PackageType packageType);
        public PackageType? Delete(string name);
        public PackageType? Update(string name, string description);
    }
}
