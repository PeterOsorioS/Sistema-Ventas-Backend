using Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Sistema_Ventas.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
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
    }
}
