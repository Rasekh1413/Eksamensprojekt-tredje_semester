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

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestFailedGetAllShelfs()
        //{
        //    //Arrange
        //    IServiceShelf _service = new ServiceShelf();
        //    List<Shelf> _allShelf = _service.GetAll();
        //}

        [TestMethod]
        public void TestAddShelf()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
            List<Shelf> _allShelf = _service.GetAll();

            //Act
            int countBefore = _allShelf.Count;

            Shelf s = new Shelf("75515f", "Ruber", true);
            _service.Add(s);

            int counterAfter = _allShelf.Count;
            _service.Delete(s.MAC);

            //Assert
            Assert.AreEqual(countBefore + 1, counterAfter);
        }

        [TestMethod]
        public void TestGetShelfByMAC()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
            List<Shelf> _allShelf = _service.GetAll();

            //Act
            Shelf sh = new Shelf("8855", "Bracelets", true);
            _service.Add(sh);

            Shelf? foundShelf = _service.GetByMAC(sh.MAC);
            _service.Delete(sh.MAC);

            //Assert
            Assert.AreEqual(sh, foundShelf);
        }

        [TestMethod]
        public void TestDeleteShelf()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
            List<Shelf> _allShelf = _service.GetAll();

            //Act
            Shelf s = new Shelf("0987h", "Napkin", true);
            _service.Add(s);
            int counterBefore = _allShelf.Count;

            _service.Delete(s.MAC);
            int counterAfter = _allShelf.Count;

            //Assert
            Assert.AreEqual(counterBefore - 1, counterAfter);
        }
        [TestMethod]
        public void TestUpdateShelfPackageType()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
            //List<Shelf> _allShelf = _service.GetAll();

            //Act
            Shelf s = new Shelf("977r4", "Napkin", true);
            string newPTName = "rubber duck";

            Shelf? updatesShelf = _service.UpdatePackageType(s.MAC, newPTName);
            _service.Delete(s.MAC);

            //Assert
            Assert.AreEqual(updatesShelf.PackageTypeName, newPTName);

        }

        public void TestUpdateShelfStatus()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
            //List<Shelf> _allShelf = _service.GetAll();

            //Act
            Shelf s = new Shelf("ofg876", "Napkin", false);
            bool newStatus = true;

            Shelf? updatesShelf = _service.UpdateStatus(s.MAC, newStatus);

            //Assert
            Assert.AreEqual(updatesShelf.IsStocked, newStatus);
        }
    }
}
