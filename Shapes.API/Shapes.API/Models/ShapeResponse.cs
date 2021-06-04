using Shapes.API.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.API.Models
{
    public class ShapeResponse
    {
        /// <summary>
        /// Information about the shape such as no. of angles, no. of sides, family & formulas for area and perimeter
        /// </summary>
        public IShape Information { get; set; }

        /// <summary>
        /// Result of computing area
        /// </summary>
        public float Area { get; set; }

        /// <summary>
        /// Result of computing perimeter
        /// </summary>
        public float Perimeter { get; set; }
    }
}
