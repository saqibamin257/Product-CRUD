using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRODUCT_CRUD.Contracts.DBModel;
using PRODUCT_CRUD.Services;

namespace PRODUCT_CRUD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService) 
        {
            this.productService = _productService;
        }
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> GetAllProducts() 
        {
            try 
            {
                return Ok(await productService.GetAllProducts());
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from Database");
            }
        }
        [HttpGet("{id:int}")]        
        public async Task<ActionResult<Product>> GetProductById(int id) 
        {
                try
                {
                    var result = await productService.GetProductById(id);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return result;
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
                }
        }
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product) 
        {
            try 
            {
                if(product== null)
                    return BadRequest();

                var createdProduct= await productService.AddProduct(product);
                return CreatedAtAction(nameof(GetProductById), new { Id = createdProduct.ProductID }, createdProduct);                
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new product record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id,Product product) 
        {
            try 
            {
                if (id != product.ProductID) 
                    return BadRequest("Product Id mismatch");
                
                var prod= await productService.GetProductById(id);
                if (prod == null) 
                {
                    return NotFound($"product with id:{id} not found.");
                }
                return await productService.UpdateProduct(product);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id) 
        {
            try 
            {
                var product = await productService.GetProductById(id);
                if (product == null) 
                {
                    return NotFound($"Product with id:{id} not found");
                }
                return await productService.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
