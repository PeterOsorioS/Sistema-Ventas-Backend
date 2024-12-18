﻿using Exceptions;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var response = _productService.GetAllProducts();
                return Ok(response);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Create(CreateProductDTO product)
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

        [HttpGet("{id:int}")]
        public IActionResult Get(int id) 
        {
            try
            {
                var response = _productService.GetProduct(id);
                return Ok(response);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateProductDTO productDTO)
        {
            try
            {
                var response = _productService.EditProduct(id, productDTO);
                return Ok(response);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                await _productService.DeleteProduct(id);
                return Ok("Producto eliminado.");
            }
            catch (NotFoundException)
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
