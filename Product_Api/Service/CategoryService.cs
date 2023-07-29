using Product_Api.Data.Model;
using Product_Api.Repository;
using MongoDB.Driver;

namespace Product_Api.Service;
public class CategoryService
{
    private readonly ICategoryRepo _categoryRepo;
    private readonly IProductRepo _productRepo;
    public CategoryService(ICategoryRepo categoryRepo, IProductRepo productRepo)
    {
        _categoryRepo = categoryRepo;
        _productRepo = productRepo;
    }
    public async Task CreateCategory(Category c)
    {
        try
        {
            await _categoryRepo.Save(c);
            return;
        }
        catch (System.Exception)
        {
            throw;
        }

    }
    public async Task<List<Category>> GetAllCategorys()
    {
        try
        {
            return await _categoryRepo.FindAll();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public async Task<Category> GetCategoryById(string id)
    {
        try
        {
            return await _categoryRepo.FindById(id);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public async Task UpdateCategory(string id, Category c)
    {
        try
        {
            await _categoryRepo.Update(id, c);
            return;
        }
        catch (System.Exception)
        {
            throw;
        }

    }
    public async Task DeleteCategory(string id)
    {
        try
        {
            await _categoryRepo.Delete(id);
            return;
        }
        catch (System.Exception)
        {
            throw;
        }

    }

    public async Task AddProducts(string entityId, List<string> pId)
    {

        Category cateOnWork = await _categoryRepo.FindById(entityId);
        if (cateOnWork == null)
        {
            return;
        }
        foreach (string id in pId)
        {
            Product productToAdd = await _productRepo.FindById(id);
            if (productToAdd == null)
            {
                return;
            }
            if (productToAdd.CategoryId == null)
            {
                productToAdd.CategoryId = new List<string>();
            }
            productToAdd.CategoryId.Add(entityId);
            await _productRepo.Update(id, productToAdd);
        }

        return;
    }
    public async Task RemoveProducts(string entityId, List<string> pId)
    {

        Category cateOnWork = await _categoryRepo.FindById(entityId);
        if (cateOnWork == null)
        {
            return;
        }
        foreach (string id in pId)
        {
            Product productToAdd = await _productRepo.FindById(id);
            if (productToAdd == null)
            {
                return;
            }
            if (productToAdd.CategoryId == null)
            {
                return;
            }
            if (productToAdd.CategoryId.Contains(entityId))
            {
                productToAdd.CategoryId.Remove(entityId);
                await _productRepo.Update(id, productToAdd);
            }

        }
        return;
    }
}