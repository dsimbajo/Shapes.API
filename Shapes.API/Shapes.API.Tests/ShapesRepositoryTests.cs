using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.API.Models;
using Shapes.API.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapes.API.Tests
{
    [TestClass]
    public class ShapesRepositoryTests
    {
        private readonly ShapesRepository _shapeRepository;
        private readonly ComputationService _computationService;
        private readonly Shape _shape;

        public ShapesRepositoryTests()
        {

            _shapeRepository = new ShapesRepository();
            _computationService = new ComputationService();
            _shape = new Shape()
            {
                Id = Guid.Parse("eb599282-b172-4841-9607-69d80826e8c8"),
                Name = "Square",
                NoOfAngles = 4,
                NoOfSides = 4,
                Family = "Rectangle, Rhombus",
                AdditionalInformation = "All squares are also parallelograms.",
                AreaFormula = "width * 4;",
                PerimeterFormula = "width * 4;",
                Variables = new Dictionary<string, object> { { "width", 0 } }
            };
        }

        [TestMethod]
        public void ShapesRepository_GetAll_Test()
        {

            var val = _shapeRepository.GetAll();

            var shapes = _shapeRepository.GetAll().ToList();

            Assert.AreEqual(shapes.ToList().Count, 3);

        }

        [TestMethod]
        public void ShapesRepository_GetByName()
        {
            var shape = _shapeRepository.GetByName("Square");

            if (shape == null)
            {
                _shapeRepository.Add(_shape);
            }

            shape = _shapeRepository.GetByName("Square");

            Assert.IsNotNull(shape);
            Assert.AreEqual(shape.Name, "Square");
        }

        [TestMethod]
        public void ShapesRepository_GetById()
        {
            var id = Guid.Parse("eb599282-b172-4841-9607-69d80826e8c8");
    
            var shape = _shapeRepository.GetById(id);

            if (shape == null)
            {
                _shapeRepository.Add(_shape);
            }

            shape = _shapeRepository.GetByName("Square");

            Assert.IsNotNull(shape);
            Assert.AreEqual(shape.Id.ToString(), "eb599282-b172-4841-9607-69d80826e8c8");
        }

        [TestMethod]
        public void ShapesRepository_Add_Test()
        {

            var shape = new Shape()
            {
                Name = "Special",
                Id = Guid.NewGuid(),
                NoOfSides = 3,
                NoOfAngles = 6,
                AdditionalInformation = "This is not a common shape"
            };

            _shapeRepository.Add(shape);

            var newShape = _shapeRepository.GetById(shape.Id);

            Assert.AreEqual(newShape.Name, "Special");
            Assert.AreEqual(newShape.NoOfAngles, 6);
            Assert.AreEqual(newShape.NoOfSides, 3);
            Assert.AreEqual(newShape.AdditionalInformation, "This is not a common shape");

        }

        [TestMethod]
        public void ShapesRepository_Update_Test()
        {

            var shape = _shapeRepository.GetByName("Square");

            shape.Name = "Trapezoid";
            shape.NoOfAngles = 5;

            _shapeRepository.Update(shape.Id, shape);

            var foundShape = _shapeRepository.GetByName("Trapezoid");

            Assert.IsNotNull(foundShape);
            Assert.AreEqual(foundShape.Name, "Trapezoid");
            Assert.AreEqual(foundShape.NoOfAngles, 5);
        }

        [TestMethod]
        public void ShapesRepository_Delete_Test()
        {

            var shape = _shapeRepository.GetByName("Square");

            _shapeRepository.Delete(shape.Id);

            var foundShape = _shapeRepository.GetById(shape.Id);

            Assert.IsNull(foundShape);
           
        }

    }
}
