
namespace Product_Api.Repository;
public interface IBaseRepo<T, ID> : IDisposable where T : class
{
    public Task<List<T>> FindAll();
    public Task<T> FindById(ID entityId);
    public Task Save(T entity);
    public Task Update(ID entityId, T entity);
    public Task Delete(ID entityId);
}