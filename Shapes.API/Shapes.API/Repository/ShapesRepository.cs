using Shapes.API.Models;
using Shapes.API.Models.Shapes;
using Shapes.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.API
{
    public class ShapesRepository : IRepository<Shape>
    {

        public Shape Add(Shape item)
        {
            ShapeContext.Shapes.Add(item);

            return GetById(item.Id);
        }

        public bool Delete(Guid id)
        {
            try
            {

                var shape = GetById(id);
                ShapeContext.Shapes.Remove(shape);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public IEnumerable<Shape> GetAll()
        {
            return ShapeContext.Shapes.ToList() as IEnumerable<Shape>;
        }

        public Shape GetById(Guid id)
        { 
            return ShapeContext.Shapes.Where(s => s.Id == id).FirstOrDefault() as Shape;
        }

        public Shape GetByName(string name)
        {
            return ShapeContext.Shapes.Find(s => s.Name == name) as Shape;
        }

        public Shape Update(Guid id, Shape item)
        {

            var foundItem = ShapeContext.Shapes.Where(s => s.Id == id).FirstOrDefault();

            foundItem.Name = item.Name;
            foundItem.Family = item.Family;
            foundItem.AdditionalInformation = item.AdditionalInformation;
            foundItem.NoOfAngles = item.NoOfAngles;
            foundItem.NoOfSides = item.NoOfSides;
            foundItem.AreaFormula = item.AreaFormula;
            foundItem.PerimeerFormula = item.PerimeerFormula;

            return (Shape)foundItem;
        }

     
    }

    public static class ShapeContext
    {
        private static List<IShape> _shapesContext = null;

        public static List<IShape> Shapes 
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

        private static List<IShape> GetShapes()
        {

            return new List<IShape>
            {
                new Shape
                {
                    Id = Guid.Parse("eb599282-b172-4841-9607-69d80826e8c8"),
                    Name = "Square",
                    NoOfAngles = 4,
                    NoOfSides = 4,
                    Family = "Rectangle, Rhombus",
                    AdditionalInformation = "All squares are also parallelograms.",
                    AreaFormula = "width * 4;",
                    PerimeerFormula = "width * 4;"
                },
                new Shape
                {
                    Id = Guid.NewGuid(),
                    Name ="Triangle",
                    NoOfAngles = 3,
                    NoOfSides = 3,
                    AdditionalInformation = "There are different kinds of Triangle",
                    AreaFormula = "(b * h) / 2",
                    PerimeerFormula = "(b + (h * 2))"
                },
                new Shape
                {
                    Id = Guid.NewGuid(),
                    Name = "Circle",
                    NoOfSides = 0,
                    NoOfAngles = 0,
                    AdditionalInformation = "Circles have a point in the centre from which each point on the diameter is equidistant.",
                    AreaFormula = "(3.14 * (r * r))",
                    PerimeerFormula = "(2 * 3.14 * r)"
                }
            };

        }
    }
}
