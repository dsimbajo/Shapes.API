using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.API.Tests
{
    [TestClass]
    public class ComputeServiceTests
    {
        [TestMethod]
        public void ComputeFormula_Test()
        {
            var formula = "3.14 * (r * r)";
            var variables = new Dictionary<string, object> { { "r", 12 } };

            var computeService = new ComputationService(formula, variables);

            var result = computeService.Compute();

            Assert.AreEqual(result, 452.16);
        }

    }
}
