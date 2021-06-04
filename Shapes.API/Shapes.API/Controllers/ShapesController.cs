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
        private readonly ComputationService _computationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapesRepository"></param>
        public ShapesController(ShapesRepository shapesRepository, ComputationService computationService)
        {
            _shapesRepository = shapesRepository;
            _computationService = computationService;
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
        /// <param name="shape">You can add your own formula for area and perimeter on the shape by using variables a, b, c and with initial value of 0 e.g. (a + b + c)</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Shape shape)
        {
            try
            {
                var newShape = _shapesRepository.Add(shape);

                return Created("/shape", newShape);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, "Adding Shape Error");
            }

           
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
            try
            {
                var foundShape = _shapesRepository.GetById(id);

                if (foundShape == null)
                {
                    return NotFound();
                }

                var updatedShape = _shapesRepository.Update(id, shape);

                return Ok(updatedShape);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, "Adding Shape Error");
            }
          

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

                square.Variables["width"] = width;

                var response = new ShapeResponse
                {
                    Information = square,
                    Area = width == 0 ? 0 : _computationService.Compute(square.AreaFormula,square.Variables),
                    Perimeter = width == 0 ? 0 : _computationService.Compute(square.PerimeterFormula, square.Variables)
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

                triangle.Variables["b"] = shapeBase;
                triangle.Variables["h"] = height;

                var response = new ShapeResponse
                {
                    Information = triangle,
                    Area = (shapeBase == 0 && height == 0) ? 0 : _computationService.Compute(triangle.AreaFormula, triangle.Variables),
                    Perimeter = (shapeBase == 0 && height == 0) ? 0 : _computationService.Compute(triangle.PerimeterFormula, triangle.Variables)
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

                circle.Variables["r"] = radius;

                var response = new ShapeResponse
                {
                    Information = circle,
                    Area = (radius == 0) ? 0 : _computationService.Compute(circle.AreaFormula, circle.Variables),
                    Perimeter = (radius == 0) ? 0 : _computationService.Compute(circle.PerimeterFormula, circle.Variables)
                };

                return Ok(response);


            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, statusCode: 500);
            }


        }

        /// <summary>
        /// Get other shape information that was added on the database
        /// </summary>
        /// <param name="request">Supply name of the shape added on the database, and the values of the variables for area and perimeter formula </param>
        /// <returns></returns>
        [HttpPost]
        [Route("shape")]
        public IActionResult GetShapeInformation([FromBody] ShapeRequest request)
        {
            try
            {
                var shape = _shapesRepository.GetByName(request.Name);

                shape.Variables["a"] = request.VariableA;
                shape.Variables["b"] = request.VariableB;
                shape.Variables["c"] = request.VariableC;

                var response = new ShapeResponse
                {
                    Information = shape,
                    Area = _computationService.Compute(shape.AreaFormula, shape.Variables),
                    Perimeter = _computationService.Compute(shape.PerimeterFormula, shape.Variables)
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
