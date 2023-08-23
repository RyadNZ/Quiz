using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Model.DataModel;

namespace ProductProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {        
        private readonly ProductService _productService;
        private readonly CloudinaryService _cloudinaryService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            try
            {
                var product = _productService.GetProduct(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed with msg " + ex.Message);
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch(Exception ex)
            {
                throw new Exception("Failed with msg " + ex.Message);
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts(int page, int pageSize, string productName, string category)
        {
            try
            {
                var products = _productService.GetProducts(page, pageSize, productName, category);
                return Ok(products);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed with msg " + ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            try
            {
                _productService.Add(product);
                return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed with msg " + ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            try
            {
                if (id != product.ProductId)
                {
                    return BadRequest();
                }

                _productService.Update(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed with msg " + ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _productService.GetProduct(id);

                if (product == null)
                {
                    return NotFound();
                }

                _productService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed with msg " + ex.Message);
            }
        }
        [HttpPost("upload-image/{productId}")]
        public  IActionResult UploadImage(int productId, IFormFile file)
        {
            try
            {
                var product = _productService.GetProduct(productId);
                if (product == null)
                {
                    return NotFound("Product not found");
                }

                var imageUrl = _cloudinaryService.UploadImage(file.OpenReadStream(), productId.ToString());


                var img = new Image
                {
                    ImgUrl = imageUrl,
                    ProductId = productId
                };
                _productService.AddImageToProduct(productId, img);

                _productService.Update(product);

                return Ok(new { ImageUrl = imageUrl });
            }
            catch (Exception ex)
            {
                throw new Exception("Failed with msg " + ex.Message);
            }
        }
        [HttpDelete("remove-image/{productId}")]
        public IActionResult RemoveImage(int productId, int imageId)
        {
            try
            {
                var product = _productService.GetProduct(productId);
                if (product == null)
                {
                    return NotFound("Product not found");
                }
                _productService.RemoveImageFromProduct(productId, imageId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed with msg " + ex.Message);
            }
        }
    }
}
