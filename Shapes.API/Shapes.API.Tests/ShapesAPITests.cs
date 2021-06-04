using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.API.Controllers;
using Shapes.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Z.Expressions;

namespace Shapes.API.Tests
{
    [TestClass]
    public class ShapesAPITests
    {
        private readonly ShapesController _shapesController;

        public ShapesAPITests()
        {
            var shapesRepository = new ShapesRepository();
            var computationService = new ComputationService();
            _shapesController = new ShapesController(shapesRepository, computationService);
        }

        [TestMethod]
        public void ShapesAPI_GetSquareInformation_With_Provided_Width()
        {

            int width = 4;

            var result = _shapesController.GetSquareInformation(width) as OkObjectResult;

            var square = (ShapeResponse)result.Value;

            Assert.IsNotNull(square);
            Assert.AreEqual(square.Area, 16);
            Assert.AreEqual(square.Perimeter, 16);
        }

        [TestMethod]
        public void ShapesAPI_GetSquareInformation_Without_Width()
        {

            int width = 0;

            var result = _shapesController.GetSquareInformation(width) as OkObjectResult;

            var square = (ShapeResponse)result.Value;

            Assert.IsNotNull(square);
            Assert.AreEqual(square.Area, 0);
            Assert.AreEqual(square.Perimeter, 0);
        }

        [TestMethod]
        public void ShapesAPI_GetTriangleInformation_With_Provided_BaseAndHeight()
        {

            int shapeBase = 4;
            int shapeHeight = 12;

            var result = _shapesController.GetTriangleInformation(shapeBase, shapeHeight) as OkObjectResult;

            var triangle = (ShapeResponse)result.Value;

            Assert.IsNotNull(triangle);
            Assert.AreEqual(triangle.Area, 24);
            Assert.AreEqual(triangle.Perimeter, 28);
        }

        [TestMethod]
        public void ShapesAPI_GetTriangleInformation_Without_BaseAndHeight()
        {

            int shapeBase = 0;
            int shapeHeight = 0;

            var result = _shapesController.GetTriangleInformation(shapeBase, shapeHeight) as OkObjectResult;

            var triangle = (ShapeResponse)result.Value;

            Assert.IsNotNull(triangle);
            Assert.AreEqual(triangle.Area, 0);
            Assert.AreEqual(triangle.Perimeter, 0);
        }

    }


}
