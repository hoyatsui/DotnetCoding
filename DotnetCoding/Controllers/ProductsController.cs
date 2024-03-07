using Microsoft.AspNetCore.Mvc;
using DotnetCoding.Core.Models;
using DotnetCoding.Services.Interfaces;
using DotnetCoding.Core.Exceptions;

namespace DotnetCoding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetProductList()
        {
            var productDetailsList = await _productService.GetAllProducts();
            if (productDetailsList == null)
            {
                return NotFound();
            }
            return Ok(productDetailsList);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveProducts()
        {
            var productLists = await _productService.GetActiveProducts();
            if (productLists == null)
            {
                return NotFound();
            }
            return Ok(productLists);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDetails productDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdProduct = await _productService.CreateProduct(productDetails);
                return CreatedAtAction(nameof(GetActiveProducts), new { id = createdProduct.Id }, createdProduct);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApprovalRequiredException ex)
            {
                return StatusCode(202, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string? productName, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var products = await _productService.SearchProducts(productName, minPrice, maxPrice, startDate, endDate);
            return Ok(products);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDetails productDetail)
        {
           // if(id != productDetail.Id)
           // {
            //    return BadRequest("Product ID doesn't match.");
           // }
            try
            {
                productDetail.Id = id;
                bool isSuccess = await _productService.UpdateProduct(productDetail);
                if (isSuccess) return Ok("Product updated.");
                else return StatusCode(202, "Product update request processed");
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id) {
            try { await _productService.DeleteProduct(id);

                return Ok("Product delete request processed.");
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
