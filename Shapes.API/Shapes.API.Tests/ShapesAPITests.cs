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
        [TestMethod]
        public void ShapesAPI_GetSquareInformation_With_Provided_Width()
        {
            var repository = new ShapesRepository();

            var controller = new ShapesController(repository);

            int width = 4;

            var result = controller.GetSquareInformation(width) as OkObjectResult;

            var square = (ShapeResponse)result.Value;

            Assert.IsNotNull(square);
            Assert.AreEqual(square.Area, 16);
            Assert.AreEqual(square.Perimeter, 16);
        }

        [TestMethod]
        public void ShapesAPI_GetSquareInformation_Without_Width()
        {
            var repository = new ShapesRepository();

            var controller = new ShapesController(repository);

            int width = 0;

            var result = controller.GetSquareInformation(width) as OkObjectResult;

            var square = (ShapeResponse)result.Value;

            Assert.IsNotNull(square);
            Assert.AreEqual(square.Area, 0);
            Assert.AreEqual(square.Perimeter, 0);
        }

        [TestMethod]
        public void ShapesAPI_GetTriangleInformation_With_Provided_BaseAndHeight()
        {
            var repository = new ShapesRepository();

            var controller = new ShapesController(repository);

            int shapeBase = 4;
            int shapeHeight = 12;



            var result = controller.GetTriangleInformation(shapeBase,shapeHeight) as OkObjectResult;

            var triangle = (ShapeResponse)result.Value;

            Assert.IsNotNull(triangle);
            Assert.AreEqual(triangle.Area, 24);
            Assert.AreEqual(triangle.Perimeter, 28);
        }

        [TestMethod]
        public void ShapesAPI_GetTriangleInformation_Without_BaseAndHeight()
        {
            var repository = new ShapesRepository();

            var controller = new ShapesController(repository);

            int shapeBase = 0;
            int shapeHeight = 0;



            var result = controller.GetTriangleInformation(shapeBase, shapeHeight) as OkObjectResult;

            var triangle = (ShapeResponse)result.Value;

            Assert.IsNotNull(triangle);
            Assert.AreEqual(triangle.Area, 0);
            Assert.AreEqual(triangle.Perimeter, 0);
        }

        [TestMethod]
        public void Test()
        {


            float result = Eval.Execute<float>("X + X", new { X = 2 });


        }

    }


}
