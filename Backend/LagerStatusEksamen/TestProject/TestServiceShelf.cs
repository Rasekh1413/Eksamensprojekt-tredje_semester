using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Models;
using LagerStatusEksamen.Services;
using Microsoft.AspNetCore.Hosting.Server;

namespace TestProject
{
    [TestClass]
    public sealed class TestServiceShelf
    {
        [TestMethod]
        public void TestGetAllShelfs()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
            List<Shelf> _allShelf = _service.GetAll();

            //Assert
            Assert.IsNotNull(_allShelf);
        }

        [TestMethod]
        public void TestAddShelf()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();

            //Act
            int countBefore = _service.GetAll().Count();

            Shelf s = new Shelf("75515f", "Ruber", true);
            _service.Add(s);

            int counterAfter = _service.GetAll().Count();
            _service.Delete(s.MAC);

            //Assert
            Assert.AreEqual(countBefore + 1, counterAfter);
        }

        [TestMethod]
        public void TestGetShelfByMAC()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();

            //Act
            Shelf sh = new Shelf("8855", "Ruber", true);
            _service.Add(sh);

            Shelf? foundShelf = _service.GetByMAC(sh.MAC);
            _service.Delete(sh.MAC);

            //Assert
            Assert.AreEqual(sh.MAC, foundShelf.MAC);
        }

        [TestMethod]
        public void TestDeleteShelf()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
     
            //Act
            Shelf s = new Shelf("0987h", "Ruber", true);
            _service.Add(s);
            int counterBefore = _service.GetAll().Count();

            _service.Delete(s.MAC);
            int counterAfter = _service.GetAll().Count();

            //Assert
            Assert.AreEqual(counterBefore - 1, counterAfter);
        }

        [TestMethod]
        public void TestUpdateShelfPackageType()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
          
            //Act
            Shelf s = new Shelf("977r4", "Ruber", true);
            _service.Add(s);
            string newPTName = "rubber duck";

            Shelf? updatesShelf = _service.UpdatePackageType(s.MAC, newPTName);
            _service.Delete(s.MAC);

            //Assert
            Assert.AreEqual(updatesShelf.PackageTypeName, newPTName);
        }

        [TestMethod]
        public void TestUpdateShelfStatus()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();

            //Act
            Shelf s = new Shelf("ofg876", "Ruber", false);
            _service.Add(s);
            bool newStatus = true;

            Shelf? updatesShelf = _service.UpdateStatus(s.MAC, newStatus);
            _service.Delete(s.MAC);

            //Assert
            Assert.AreEqual(updatesShelf.IsStocked, newStatus);
        }
    }
}
