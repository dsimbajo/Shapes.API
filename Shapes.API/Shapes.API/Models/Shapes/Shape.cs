using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.API.Models.Shapes
{
    public class Shape : IShape
    {
        private readonly ComputationService _computationService;


        public Shape()
        {

        }
        /// <summary>
        /// Shape Id 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Shape Name registered on database
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// No of Sides
        /// </summary>
        public int NoOfSides { get; set; }

        /// <summary>
        /// No of Angles
        /// </summary>
        public int NoOfAngles { get; set; }

        /// <summary>
        /// Shape of family, can be null
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Additional Information about the shape
        /// </summary>
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// Formula for computing shape area in string format, mathematical symbols are not allowed such as Pi or square root
        /// </summary>
        public string AreaFormula { get; set; }

        /// <summary>
        /// Formula for computing shape perimeter in string format, mathematical symbols are not allowed such as Pi or square root
        /// </summary>
        public string PerimeterFormula { get; set; }

        /// <summary>
        /// Collection of variables used in area and perimeter formula
        /// </summary>
        public Dictionary<string, object> Variables {get; set;}       
    }
}
