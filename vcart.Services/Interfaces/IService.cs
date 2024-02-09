
namespace vcart.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity FindBy(object id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
    }
}
