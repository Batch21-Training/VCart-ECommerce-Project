using vcart.Repositories.Interfaces;
using vcart.Services.Interfaces;

namespace vcart.Services.Implementations
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repo;
        public Service(IRepository<TEntity> repo)
        {
            _repo = repo;
        }
        public void Add(TEntity entity)
        {
            _repo.Add(entity);
            _repo.SaveChanges();
        }

        public void Delete(object id)
        {
            _repo.Delete(id);
            _repo.SaveChanges();
        }

        public TEntity FindBy(object id)
        {
            return _repo.FindBy(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public void Update(TEntity entity)
        {
            _repo.Update(entity);
            _repo.SaveChanges();
        }
    }
}
