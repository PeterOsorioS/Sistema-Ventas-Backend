using Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interface;

namespace Sistema_Ventas.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public IActionResult Create(ProductDTO product)
        {
            try
            {
                var response = _productService.CreateProduct(product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var response = _productService.GetAllProducts();
                return Ok(response);
            }
            catch (BadRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id) 
        {
            try
            {
                var response = _productService.GetProduct(id);
                return Ok(response);
            }
            catch (BadRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] ProductDTO productDTO)
        {
            try
            {
                var response = _productService.UpdateProduct(productDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
