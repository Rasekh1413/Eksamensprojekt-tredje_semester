using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Models;

namespace LagerStatusEksamen.Services
{
    public class ServiceShelf : IServiceShelf
    {
        public Shelf Add(Shelf shelf)
        {
            throw new NotImplementedException();
        }

        public Shelf? Delete(string mac)
        {
            throw new NotImplementedException();
        }

        public List<Shelf> GetAll()
        {
            throw new NotImplementedException();
        }

        public Shelf? GetByMAC(string mac)
        {
            throw new NotImplementedException();
        }

        public Shelf? UpdatePackageType(string mac, string type)
        {
            throw new NotImplementedException();
        }

        public Shelf? UpdateStatus(string mac, bool status)
        {
            throw new NotImplementedException();
        }
    }
}
