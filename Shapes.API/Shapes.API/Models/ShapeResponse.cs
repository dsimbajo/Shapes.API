using Shapes.API.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.API.Models
{
    public class ShapeResponse
    {
        public IShape Information { get; set; }

        public float Area { get; set; }

        public float Perimeter { get; set; }
    }
}
