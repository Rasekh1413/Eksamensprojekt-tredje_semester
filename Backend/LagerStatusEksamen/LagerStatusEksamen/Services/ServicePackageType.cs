using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Models;
using System.Diagnostics.Eventing.Reader;

namespace LagerStatusEksamen.Services
{
    public class ServicePackageType : IServicePackageType
    {
        private readonly List<PackageType> _packageTypes = new List<PackageType>();
        public PackageType Add(PackageType packageType)
        {
            if (packageType == null)
                throw new ArgumentNullException(nameof(packageType));

            // Prevent duplicates by name
            if (_packageTypes.Any(p => p.Name.Equals(packageType.Name, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Package type already exists.");

            _packageTypes.Add(packageType);
            return packageType;
        }


        // Read: Get all
        public List<PackageType> GetAll()
        {
            return _packageTypes;
        }

        // Read: Get by name
        public PackageType? GetByName(string name)
        {
            return _packageTypes.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public PackageType? Update(PackageType packageType)
        {
            if (packageType == null)
                throw new ArgumentNullException(nameof(packageType));

            var existing = GetByName(packageType.Name);
            if (existing == null)
                return null;

            // Update properties
            existing.Description = packageType.Description;

            return existing;
        }

        public PackageType? Delete(string name)
        {
            var existing = GetByName(name);
            if (existing == null)
                return null;

            _packageTypes.Remove(existing);
            return existing;
        }
    }
}
