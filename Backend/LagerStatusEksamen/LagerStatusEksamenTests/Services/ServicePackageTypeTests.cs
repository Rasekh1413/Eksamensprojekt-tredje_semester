//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using LagerStatusEksamen.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Runtime.InteropServices;
//using Microsoft.AspNetCore.Hosting.Server.Features;
//using LagerStatusEksamen.Models;

//namespace LagerStatusEksamen.Services.Tests
//{
//    [TestClass()]
//    public class ServicePackageTypeTests
//    {
//        [TestMethod()]
//        public void AddTest()
//        {
//            PackageType box1 = new PackageType("Box1", "1 cardboard box"); // Arrange
//            PackageType box2 = new PackageType("Box2", "2 cardboard box");
//            PackageType box3 = new PackageType("Box3", "3 cardboard box");

//            ServicePackageType serviceunkown1 = new ServicePackageType();

//            // Act
//            serviceunkown1.Add(box1);
//            serviceunkown1.Add(box2);
//            serviceunkown1.Add(box3);
//            Assert.IsTrue(serviceunkown1.GetAll().Contains(box1));
//        }

//        [TestMethod()]
//        public void GetAllTest()
//        {
//            PackageType box1 = new PackageType("Box1", "1 cardboard box"); // Arrange
//            PackageType box2 = new PackageType("Box2", "2 cardboard box");
//            PackageType box3 = new PackageType("Box3", "3 cardboard box");

//            ServicePackageType serviceunkown1 = new ServicePackageType();
//            // Act
//            List<PackageType> pkgList = new List<PackageType>();
//            serviceunkown1.Add(box1);
//            serviceunkown1.Add(box2);
//            serviceunkown1.Add(box3);
//            pkgList.Add(box1);
//            pkgList.Add(box2);
//            pkgList.Add(box3);

//            var result = serviceunkown1.GetAll();
//            CollectionAssert.AreEqual(pkgList, result);
//        }

//        [TestMethod()]
//        public void GetByNameTest()
//        {
//            PackageType box1 = new PackageType("Box1", "1 cardboard box"); // Arrange
//            PackageType box2 = new PackageType("Box2", "2 cardboard box");
//            PackageType box3 = new PackageType("Box3", "3 cardboard box");

//            ServicePackageType serviceunkown1 = new ServicePackageType();
//            // Act
//            serviceunkown1.Add(box1);
//            serviceunkown1.Add(box2);
//            serviceunkown1.Add(box3);
//            var result = serviceunkown1.GetByName("Box2");

//            Assert.AreEqual(box2, result);
//        }

//        [TestMethod()]
//        public void UpdateTest()
//        {
//            PackageType box1 = new PackageType("Box1", "1 cardboard box"); // Arrange
//            ServicePackageType serviceunkown1 = new ServicePackageType();
//            // Act
//            serviceunkown1.Add(box1);
//            box1.Description = "Updated description";

//            var result = serviceunkown1.Update(box1.Name, box1.Description);
//            Assert.AreEqual(box1, result);
//        }

//        [TestMethod()]
//        public void DeleteTest()
//        {
//            PackageType box1 = new PackageType("Box1", "1 cardboard box"); // Arrange
//            ServicePackageType serviceunkown1 = new ServicePackageType();
//            // Act
//            serviceunkown1.Add(box1);
//            var result = serviceunkown1.Delete("Box1");
//            if (result == box1)
//            {
//                return;
//            }
//            Assert.IsTrue(serviceunkown1.GetAll().Contains(box1));
//        }
//    }
//}