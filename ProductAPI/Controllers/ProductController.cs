using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Domains;
using ProductAPI.Interfaces;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository { get; set; }

        public ProductController()
        {
            _productRepository = new ProductRepository();

        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productRepository.GetAll());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                _productRepository.Create(product);

                return StatusCode(201, product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, Product product)
        {
            try
            {
                _productRepository.Update(id, product);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productRepository.Delete(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                return Ok(_productRepository.SearchById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
