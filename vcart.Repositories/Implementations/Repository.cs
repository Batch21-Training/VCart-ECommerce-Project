using vcart.Core;
using vcart.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace vcart.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _db;
        public Repository(DbContext db)
        {
            _db = db;
        }

        //protected AppDbContext _db;
        //public Repository(AppDbContext db)
        //{
        //    _db = db;
        //}

        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public void Delete(object id)
        {
            TEntity entity = _db.Set<TEntity>().Find(id);
            if(entity != null)
            {
                _db.Set<TEntity>().Remove(entity);
            }
        }

        public TEntity FindBy(object id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }

        public int SaveChanges()
        {
           return _db.SaveChanges();
        }
    }
}
