using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.API.Models;
using Shapes.API.Models.Shapes;
using System;
using System.Linq;

namespace Shapes.API.Tests
{
    [TestClass]
    public class ShapesRepositoryTests
    {
        [TestMethod]
        public void ShapesRepository_GetAll_Test()
        {
            var repository = new ShapesRepository();

            var shapes = repository.GetAll().ToList();

            Assert.AreEqual(shapes.ToList().Count, 3);

        }

        [TestMethod]
        public void ShapesRepository_GetByName()
        {
            var repository = new ShapesRepository();

            var shape = repository.GetByName("Square");

            Assert.IsNotNull(shape);
            Assert.AreEqual(shape.Name, "Square");
        }

        [TestMethod]
        public void ShapesRepository_GetById()
        {
            var id = Guid.Parse("eb599282-b172-4841-9607-69d80826e8c8");
            var repository = new ShapesRepository();
            var shape = repository.GetById(id);

            Assert.IsNotNull(shape);
            Assert.AreEqual(shape.Id.ToString(), "eb599282-b172-4841-9607-69d80826e8c8");
        }

        [TestMethod]
        public void ShapesRepository_Add_Test()
        {
            var repository = new ShapesRepository();

            var shape = new Shape
            {
                Name = "Special",
                Id = Guid.NewGuid(),
                NoOfSides = 3,
                NoOfAngles = 6,
                AdditionalInformation = "This is not a common shape"
            };

            repository.Add(shape);

            var newShape = repository.GetById(shape.Id);

            Assert.AreEqual(newShape.Name, "Special");
            Assert.AreEqual(newShape.NoOfAngles, 6);
            Assert.AreEqual(newShape.NoOfSides, 3);
            Assert.AreEqual(newShape.AdditionalInformation, "This is not a common shape");

        }

        [TestMethod]
        public void ShapesRepository_Update_Test()
        {
            var repository = new ShapesRepository();

            var shape = repository.GetByName("Square");

            shape.Name = "Trapezoid";
            shape.NoOfAngles = 5;

            repository.Update(shape.Id, shape);

            var foundShape = repository.GetByName("Trapezoid");

            Assert.IsNotNull(foundShape);
            Assert.AreEqual(foundShape.Name, "Trapezoid");
            Assert.AreEqual(foundShape.NoOfAngles, 5);
        }

        [TestMethod]
        public void ShapesRepository_Delete_Test()
        {
            var repository = new ShapesRepository();

            var shape = repository.GetByName("Square");

            repository.Delete(shape.Id);

            var foundShape = repository.GetById(shape.Id);

            Assert.IsNull(foundShape);
           
        }

    }
}
