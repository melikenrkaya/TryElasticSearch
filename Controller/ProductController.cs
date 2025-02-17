using Microsoft.AspNetCore.Mvc;
using TryElasticSearch.Common;
using TryElasticSearch.Data.Context;
using TryElasticSearch.Data.Entity;
using TryElasticSearch.Data.Models;
using TryElasticSearch.Services;
using TryElasticSearch.Services.ProductServices;

namespace TryElasticSearch.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductServi _productService;
        private readonly ElasticSearch _elasticsearch;

        public ProductController(ApplicationDBContext context, IProductServi productService, ElasticSearch elasticsearch)
        {
            _context = context;
            _productService = productService;
            _elasticsearch = elasticsearch;
        }



        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string Product)
        {
            if (string.IsNullOrEmpty(Product))
            {
                return BadRequest("Arama sorgusu boş olamaz.");
            }
            var result = await _elasticsearch.SearchProductsAsync(Product);
            return Ok(result);
        }
        // POST api/products
        [HttpPost("{id:int}")]
        public async Task<IActionResult> CreateProduct([FromRoute] int id, [FromBody] CreateProductRequestDto createProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productModel = createProductDto.ToProductFromCreatedDTO(id);
            await _productService.CreateAsync(productModel);
            return CreatedAtAction(nameof(CreateProduct), new { id = productModel.Id }, productModel.ToProductDto());
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Ürün bilgileri eksik.");
            }

            var result = await _elasticsearch.AddProductToIndexAsync(product);
            return Ok(result);
        }



        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productModel = await _productService.DeleteProductAsync(id);
            if (productModel == null)
            {
                return NotFound("Yorum Bulunamadı");
            }
            return NoContent();

        }

    }
}