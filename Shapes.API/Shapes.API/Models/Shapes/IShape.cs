using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.API.Models.Shapes
{
    public interface IShape
    {
        float ComputeArea(Dictionary<string, object> parameters);

        float ComputePerimeter(Dictionary<string, object> parameters);

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int NoOfSides { get; set; }

        public int NoOfAngles { get; set; }

        public string Family { get; set; }

        public string AreaFormula { get; set; }

        public string PerimeterFormula { get; set; }

        public string AdditionalInformation { get; set; }
    }
}
