using Product_Api.Data;
using Product_Api.Data.Model;

namespace Product_Api.Repository.Implement;

public class ProductRepo : BaseRepo<Product, string>, IProductRepo
{
    public ProductRepo(IMongoContext context) : base(context)
    {
    }
   
}