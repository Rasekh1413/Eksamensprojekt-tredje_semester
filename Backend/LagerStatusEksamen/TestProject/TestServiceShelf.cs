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
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFailedGetAllShelfs()
        {
            //Arrange
            IServiceShelf _service = new ServiceShelf();
            List<Shelf> _allShelf = _service.GetAll();
        }

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

        }

        [TestMethod]
        public void TestDeleteShelf()
        {

        }
        [TestMethod]
        public void TestUpdateShelf()
        {

        }
    }
}
