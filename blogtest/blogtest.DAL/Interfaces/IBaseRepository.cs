using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace blogtest.DAL.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);
        IEnumerable<TEntity> Get( 
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
        );
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        void Save();
    }
}
