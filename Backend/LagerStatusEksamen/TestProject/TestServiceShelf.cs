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
            IServicePackageType _ptService = new ServicePackageType();

            //Act
            int countBefore = _service.GetAll().Count();
            PackageType pt = new PackageType("rubber Duck", "Toy for the bath");
            _ptService.Add(pt.Name,pt);

            Shelf s = new Shelf("75515f",pt.Name, true);
            _service.Add(s);

            int counterAfter = _service.GetAll().Count();
            _service.Delete(s.MAC);
            _ptService.Delete(pt.Name);

            //Assert
            Assert.AreEqual(countBefore + 1, counterAfter);
        }

        [TestMethod]
        public void TestGetShelfByMAC()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
            IServicePackageType _ptService = new ServicePackageType();

            //Act
            PackageType pt = new PackageType("Duck", "Toy for the bath");
            _ptService.Add(pt.Name, pt);

            Shelf sh = new Shelf("8855",pt.Name, true);
            _service.Add(sh);

            Shelf? foundShelf = _service.GetByMAC(sh.MAC);
            _service.Delete(sh.MAC);
            _ptService.Delete(pt.Name);

            //Assert
            Assert.AreEqual(sh.MAC, foundShelf.MAC);
        }

        [TestMethod]
        public void TestDeleteShelf()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
            IServicePackageType _ptService = new ServicePackageType();

            //Act
            PackageType pt = new PackageType("rubber Duck", "Toy for the bath");
            _ptService.Add(pt.Name,pt);
            Shelf s = new Shelf("0987h", pt.Name, true);
            _service.Add(s);

            Shelf? deletedShelf= _service.Delete(s.MAC);
            _ptService.Delete(pt.Name);

            //Assert
            Assert.AreEqual(s.MAC,deletedShelf.MAC);
        }

        [TestMethod]
        public void TestUpdateShelfPackageType()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
            IServicePackageType _ptService = new ServicePackageType();
            string newPTName = "Rubber Duck";

            //Act
            PackageType pt = new PackageType("Duck", "Toy for the bath");
            PackageType pt2 = new PackageType("Rubber Duck", "Toy for the bath");
            _ptService.Add(pt.Name, pt);
            _ptService.Add(pt2.Name, pt2);

            Shelf s = new Shelf("977r4", pt.Name, true);
            _service.Add(s);

            Shelf? updatesShelf = _service.UpdatePackageType(s.MAC, newPTName);
            _service.Delete(s.MAC);
            _ptService.Delete(pt.Name);
            _ptService.Delete(pt2.Name);

            //Assert
            Assert.AreEqual(updatesShelf.PackageTypeName, newPTName);
        }

        [TestMethod]
        public void TestUpdateShelfStatus()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
            IServicePackageType _ptService= new ServicePackageType();

            //Act
            PackageType pt = new PackageType("Duck", "Toy for the bath");
            _ptService.Add(pt.Name, pt);

            Shelf s = new Shelf("ofg876", pt.Name, false);
            _service.Add(s);
            bool newStatus = true;

            Shelf? updatesShelf = _service.UpdateStatus(s.MAC, newStatus);
            _service.Delete(s.MAC);
            _ptService.Delete(pt.Name);

            //Assert
            Assert.AreEqual(updatesShelf.IsStocked, newStatus);
        }
    }
}
