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
            return ShapeContext.Shapes.ToList();
        }

        public Shape GetById(Guid id)
        { 
            return ShapeContext.Shapes.Where(s => s.Id == id).FirstOrDefault();
        }

        public Shape GetByName(string name)
        {
            return ShapeContext.Shapes.Find(s => s.Name == name);
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
            foundItem.PerimeterFormula = item.PerimeterFormula;

            return foundItem;
        }

     
    }
}
