using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Models;
using LagerStatusEksamen.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerStatusEksamen.Services.Tests
{
    [TestClass()]
    public class ServicePackageTypeTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            IServicePackageType _servicePackageType = new ServicePackageType();

            // Act
            int countBefore = _servicePackageType.GetAll().Count();
            PackageType box1 = new PackageType("Box1", "1 cardboard box");
            _servicePackageType.Add(box1.Name, box1);

            int countAfter = _servicePackageType.GetAll().Count;


            _servicePackageType.Delete(box1.Name);
            // Assert
            Assert.AreEqual(countBefore + 1, countAfter);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Arrange
            IServicePackageType _servicePackageType = new ServicePackageType();
            PackageType box1 = new PackageType("Box1", "1 cardboard box");


            // Act
            _servicePackageType.Add(box1.Name, box1);
            List<PackageType> pkgList = _servicePackageType.GetAll();
            _servicePackageType.Delete(box1.Name);

            //Assert
            Assert.IsNotNull(pkgList);
        }

        [TestMethod()]
        public void GetByNameTest()
        {
            // Arrange
            PackageType box1 = new PackageType("Box1", "1 cardboard box"); 
            IServicePackageType serviceunkown1 = new ServicePackageType();
            // Act
            serviceunkown1.Add(box1.Name, box1);

            var result = serviceunkown1.GetByName(box1.Name);
            serviceunkown1.Delete(box1.Name);

            //Assert
            Assert.AreEqual(box1.Name, result.Name);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // Arrange
            PackageType box1 = new PackageType("Box1", "1 cardboard box"); 
            IServicePackageType serviceunkown1 = new ServicePackageType();
            string updatedDescription = "Updated description";

            // Act
            serviceunkown1.Add(box1.Name, box1);

            var result = serviceunkown1.Update(box1.Name,updatedDescription);
            serviceunkown1.Delete(box1.Name);

            //Assert
            Assert.AreEqual(result.Description, updatedDescription);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            PackageType box1 = new PackageType("Box1", "1 cardboard box"); 
            IServicePackageType serviceunkown1 = new ServicePackageType();

            // Act
            serviceunkown1.Add(box1.Name, box1);
            var result = serviceunkown1.Delete(box1.Name);
            serviceunkown1.Delete(box1.Name);

            //Assert
            Assert.AreEqual(box1.Name, result.Name);
        }
    }
}