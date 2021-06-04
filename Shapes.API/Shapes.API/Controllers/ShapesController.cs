using Microsoft.AspNetCore.Mvc;
using Shapes.API.Models;
using Shapes.API.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shapes.API.Controllers
{
    /// <summary>
    ///  API to calculate area and perimeter of the shape
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShapesController : ControllerBase
    {
        private readonly ShapesRepository _shapesRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapesRepository"></param>
        public ShapesController(ShapesRepository shapesRepository)
        {
            _shapesRepository = shapesRepository;
        }

        /// <summary>
        /// Endpoint to fetch all shapes
        /// </summary>
        /// <param name="shapeRequest"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromBody] ShapeRequest shapeRequest)
        {
            var shapes = _shapesRepository.GetAll();

            return Ok(shapes);
        }

        /// <summary>
        /// Endpoint to fetch specific shape by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Endpoint to add new shape to database
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Shape shape)
        {
            var newShape = _shapesRepository.Add(shape);

            return Created("/shape",newShape);
        }

        /// <summary>
        /// Endpoint to update specific shape in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Endpoint to delete specific shape by Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        /// <summary>
        /// Endpoint to compute square area and perimeter and retrieve information
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Endpoint to compute triangle area and perimeter and retrieve information
        /// </summary>
        /// <param name="shapeBase"></param>
        /// <param name="height"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Endpoint to compute circle area and perimeter and retrieve information
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
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
