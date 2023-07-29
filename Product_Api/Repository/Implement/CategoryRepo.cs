using Product_Api.Data;
using Product_Api.Data.Model;

namespace Product_Api.Repository.Implement;
public class CategoryRepo : BaseRepo<Category, string>, ICategoryRepo
{
    public CategoryRepo(IMongoContext context) : base(context)
    {
    }
}