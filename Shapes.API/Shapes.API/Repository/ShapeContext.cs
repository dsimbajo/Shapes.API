using Shapes.API.Models.Shapes;
using System;
using System.Collections.Generic;

namespace Shapes.API
{
    public static class ShapeContext
    {
        private static List<Shape> _shapesContext = null;

        public static List<Shape> Shapes 
        { 
            get 
            { 
                {
                    if (_shapesContext == null)
                    {
                        _shapesContext = GetShapes();

                        return _shapesContext;
                    }
                    else
                    {
                        return _shapesContext;
                    }
                }
            } 
 
        }

        private static List<Shape> GetShapes()
        {
            var computationService = new ComputationService();

            return new List<Shape>
            {
                new Shape()
                {
                    Id = Guid.Parse("eb599282-b172-4841-9607-69d80826e8c8"),
                    Name = "Square",
                    NoOfAngles = 4,
                    NoOfSides = 4,
                    Family = "Rectangle, Rhombus",
                    AdditionalInformation = "All squares are also parallelograms.",
                    AreaFormula = "width * 4;",
                    PerimeterFormula = "width * 4;",
                    Variables = new Dictionary<string, object> { {"width",0} }
                },
                new Shape()
                {
                    Id = Guid.NewGuid(),
                    Name ="Triangle",
                    NoOfAngles = 3,
                    NoOfSides = 3,
                    AdditionalInformation = "There are different kinds of Triangle",
                    AreaFormula = "(b * h) / 2",
                    PerimeterFormula = "(b + (h * 2))",
                    Variables = new Dictionary<string, object> { {"b",0}, {"h",0} }
                },
                new Shape()
                {
                    Id = Guid.NewGuid(),
                    Name = "Circle",
                    NoOfSides = 0,
                    NoOfAngles = 0,
                    AdditionalInformation = "Circles have a point in the centre from which each point on the diameter is equidistant.",
                    AreaFormula = "(3.14 * (r * r))",
                    PerimeterFormula = "(2 * 3.14 * r)",
                    Variables = new Dictionary<string, object> { {"r",0} }
                }
            };

        }
    }
}
