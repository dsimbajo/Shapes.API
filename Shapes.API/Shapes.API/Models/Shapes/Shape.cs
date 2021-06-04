using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.API.Models.Shapes
{
    public class Shape : IShape
    {

        public Shape()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NoOfSides { get; set; }
        public int NoOfAngles { get; set; }
        public string Family { get; set; }
        public string AdditionalInformation { get; set; }
        public string AreaFormula { get; set; }
        public string PerimeterFormula { get; set; }

        public float ComputeArea(Dictionary<string,object> parameters)
        {

            //TODO: Should be dependency injected
            var computeService = new ComputationService(AreaFormula, parameters);

            return computeService.Compute();
        }

        public float ComputePerimeter(Dictionary<string, object> parameters)
        {
            //TODO: Should be dependency injected
            var computeService = new ComputationService(PerimeterFormula, parameters);

            return computeService.Compute();
        }
    }
}
