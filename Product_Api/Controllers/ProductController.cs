using Product_Api.Data.Model;
using Product_Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Product_Api.Controller;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        this._productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> getAllProducts()
    {
        List<Product> all = await _productService.GetAllProducts();
        if (all == null)
        {
            return NoContent();
        }
        return Ok(all);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> getProductById(string id)
    {
        Product p = await _productService.GetProductById(id);
        if (p == null)
        {
            return NotFound();
        }
        return Ok(p);
    }
    [HttpPost]
    public async Task<ActionResult> CreateProduct(Product p)
    {
        try
        {
            await _productService.CreateProduct(p);
            return Ok("Create success");
        }
        catch (System.Exception e)
        {

            return BadRequest(e.Message);
        }
    }
    [HttpPut]
    public async Task<ActionResult> UpdateProduct(string id, Product p)
    {
        try
        {
            await _productService.UpdateProduct(id, p);

            return Ok("Update success");
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete]
    public async Task<ActionResult> DeleteProduct(string id)
    {
        try
        {
            await _productService.DeleteProduct(id);

            return Ok("Delete success");
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}