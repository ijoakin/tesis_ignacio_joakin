using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IRepository<TEntity>
    {
        IList<TEntity> GetAll();

        bool Insert(TEntity entity);
        TEntity GetById(int id);

        IQueryable<TEntity> GetQuery();

        Task<IQueryable<TEntity>> GetQueryAsync();

        Task<IList<TEntity>> GetAllAsync();

        bool Save(TEntity product);
        bool Delete(int id);
    }

}
