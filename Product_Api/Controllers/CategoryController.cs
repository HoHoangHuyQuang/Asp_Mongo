using Microsoft.AspNetCore.Mvc;
using Product_Api.Data.Model;
using Product_Api.Service;

namespace Product_Api.Controller;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> getAllCategorys(int pageNum)
    {
        if (pageNum == null || pageNum < 1)
        {
            pageNum = 1;
        }
        try
        {
            List<Category> data = await _categoryService.GetAllCategorys(pageNum);
            if (data == null)
            {
                return NoContent();
            }
            return Ok(data);
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPost]
    public async Task<ActionResult> CreateCategory(Category c)
    {
        try
        {
            await _categoryService.CreateCategory(c);
            return Ok("Create success");
        }
        catch (System.Exception e)
        {

            return BadRequest(e.Message);
        }
    }
    [HttpPut]
    public async Task<ActionResult> UpdateCategory(string id, Category c)
    {
        try
        {
            await _categoryService.UpdateCategory(id, c);

            return Ok("Update success");
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete]
    public async Task<ActionResult> DeletCategoryt(string id)
    {
        try
        {
            await _categoryService.DeleteCategory(id);

            return Ok("Delete success");
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}