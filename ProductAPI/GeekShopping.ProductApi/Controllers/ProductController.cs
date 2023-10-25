using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("Api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentException(nameof(productRepository));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ProductVO>>> GetAll()
        {
            var products = await _productRepository.FindAll();
            if (products == null || products.Count() == 0) return NotFound();

            return Ok(products);
        }


        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ProductVO>> GetById(long id)
        {
            var product = await _productRepository.FindById(id);
            if(product == null) return NotFound();

            return Ok(product);
        }


        [HttpPost("Create")]
        public async Task<ActionResult<ProductVO>> Create(ProductVO vo)
        {
            if (vo == null) return BadRequest();

            var product = await _productRepository.Create(vo);
            return Ok(product);
        }


        [HttpPut("Update")]
        public async Task<ActionResult<ProductVO>> Update(ProductVO vo)
        {
            if (vo == null) return BadRequest();

            var product = await _productRepository.Update(vo);
            return Ok(product);
        }


        [HttpDelete("Delete")]
        public async Task<ActionResult<ProductVO>> Delete(long id)
        {
            var status = await _productRepository.Delete(id);

            if(status == false) return BadRequest();
            return Ok(status);
        }



    }
}
