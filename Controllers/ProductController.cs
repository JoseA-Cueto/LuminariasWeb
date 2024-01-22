
using AutoMapper;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminariasWeb.sln.Controllers
{
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAllProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("GetProductById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductViewModel>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("AddProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddProduct([FromBody] ProductViewModel productViewModel)
        {
            try
            {
                Console.WriteLine($"Nombre del producto recibido: {productViewModel.Name}");
                Console.WriteLine($"ID de la categoría recibido: {productViewModel.CategoryId}");

                await _productService.AddProductAsync(productViewModel);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductViewModel productViewModel)
        {
            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            try
            {
                // Si se proporciona una nueva imagen, actualiza la propiedad ImagePath
                if (!string.IsNullOrEmpty(productViewModel.ImagePath))
                {
                    existingProduct.ImagePath = productViewModel.ImagePath;
                }

                await _productService.UpdateProductAsync(productViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            try
            {
                await _productService.DeleteProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }



}


