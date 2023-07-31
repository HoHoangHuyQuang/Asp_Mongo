using Product_Api.Data.Model;
using Product_Api.Repository;

namespace Product_Api.Service;
public class ProductService
{
    private readonly IProductRepo _productRepo;

    public ProductService(IProductRepo productRepo)
    {
        this._productRepo = productRepo;
    }

    public async Task CreateProduct(Product p)
    {
        try
        {
            await _productRepo.Save(p);
            return;
        }
        catch (System.Exception)
        {
            throw;
        }

    }
    public async Task<List<Product>> GetAllProducts(int pageNum)
    {
        try
        {
            var all = await _productRepo.FindAll();
            return all.Skip((pageNum - 1) * 20).Take(20).ToList();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public async Task<Product> GetProductById(string id)
    {
        try
        {
            return await _productRepo.FindById(id);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public async Task UpdateProduct(string id, Product p)
    {
        try
        {
            await _productRepo.Update(id, p);
            return;
        }
        catch (System.Exception)
        {
            throw;
        }

    }
    public async Task DeleteProduct(string id)
    {
        try
        {
            await _productRepo.Delete(id);
            return;
        }
        catch (System.Exception)
        {
            throw;
        }

    }
}