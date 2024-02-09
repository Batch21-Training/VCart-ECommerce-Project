using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vcart.Repositories.Interfaces
{
    //List<User>
    //IRepository<User>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindBy(object id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        int SaveChanges();
    }
}
