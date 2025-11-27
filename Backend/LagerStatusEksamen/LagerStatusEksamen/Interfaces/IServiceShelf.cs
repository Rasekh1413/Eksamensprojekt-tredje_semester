using LagerStatusEksamen.Models;

namespace LagerStatusEksamen.Interfaces
{
    public interface IServiceShelf
    {
        public List<Shelf> GetAll();
        public Shelf? GetByMAC(string mac);
        public Shelf Add(Shelf shelf);
        public Shelf? Delete(string mac);
        public Shelf? UpdateStatus(string mac, bool status);
        public Shelf? UpdatePackageType(string mac, string type);
    }
}
