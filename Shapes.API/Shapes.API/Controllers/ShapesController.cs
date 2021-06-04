using Microsoft.AspNetCore.Mvc;
using Shapes.API.Models;
using Shapes.API.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shapes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapesController : ControllerBase
    {
        private readonly ShapesRepository _shapesRepository;

        public ShapesController(ShapesRepository shapesRepository)
        {
            _shapesRepository = shapesRepository;
        }

        // GET: api/<ShapesController>
        [HttpGet]
        public IActionResult Get([FromBody] ShapeRequest shapeRequest)
        {
            var shapes = _shapesRepository.GetAll();

            return Ok(shapes);
        }

        // GET api/<ShapesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var foundShape = _shapesRepository.GetById(id);

            if (foundShape == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundShape);
            }
        }

        // POST api/<ShapesController>
        [HttpPost]
        public ActionResult Post([FromBody] Shape shape)
        {
            var newShape = _shapesRepository.Add(shape);

            return Created("/shape",newShape);
        }

        // PUT api/<ShapesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Shape shape)
        {
            var foundShape = _shapesRepository.GetById(id);

            if (foundShape == null)
            {
                return NotFound();
            }

            
            var updatedShape = _shapesRepository.Update(id,shape);

            return Ok(updatedShape);

        }

        // DELETE api/<ShapesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("square")]
        public IActionResult GetSquareInformation(float width)
        {
            try
            {
                var square = _shapesRepository.GetByName("Square");

                var variables = new Dictionary<string, object> { { "width", width } };

                var response = new ShapeResponse
                {
                    Information = square,
                    Area = width == 0 ? 0 : square.ComputeArea(variables),
                    Perimeter = width == 0 ? 0 : square.ComputePerimeter(variables)
                };

                return Ok(response);

            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, statusCode: 500);
            }

         
        }

        [HttpGet]
        [Route("triangle")]
        public ActionResult GetTriangleInformation(float shapeBase, float height)
        {
            try
            {
                var triangle = _shapesRepository.GetByName("Triangle");

                var variables = new Dictionary<string, object> { { "b", shapeBase }, { "h", height } };

                var response = new ShapeResponse
                {
                    Information = triangle,
                    Area = (shapeBase == 0 && height == 0) ? 0 : triangle.ComputeArea(variables),
                    Perimeter = (shapeBase == 0 && height == 0) ? 0 : triangle.ComputePerimeter(variables)
                };

                return Ok(response);

            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, statusCode: 500);
            }


        }

        [HttpGet]
        [Route("circle")]
        public ActionResult GetCircleInformation(float radius)
        {
            try
            {
                var circle = _shapesRepository.GetByName("Circle");


                var variables = new Dictionary<string, object> { { "r", radius } };

                var response = new ShapeResponse
                {
                    Information = circle,
                    Area = (radius == 0) ? 0 : circle.ComputeArea(variables),
                    Perimeter = (radius == 0) ? 0 : circle.ComputePerimeter(variables)
                };

                return Ok(response);


            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, statusCode: 500);
            }


        }
    }
}
