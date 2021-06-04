using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.API.Models.Shapes
{
    public class ShapeRequest
    {
        /// <summary>
        /// Name of the shape registered on database
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of variable (a) on area or perimeter formula
        /// </summary>
        public float VariableA { get; set; }

        /// <summary>
        /// Value of variable (b) on area or perimeter formula
        /// </summary>
        public float VariableB { get; set; }

        /// <summary>
        /// Value of variable (c) on area or perimeter formula
        /// </summary>
        public float VariableC { get; set; }

    }
}
