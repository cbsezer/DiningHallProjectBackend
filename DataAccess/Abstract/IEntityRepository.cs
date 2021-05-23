using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T,Y> where T : class, IEntity, new()
    {
        List<T> GetAll(string sqlCommand = null);
        T Get(string sqlCommand);
        void Add(T entity);
        void Update(T entity);
        void Delete(Y id);
    }
}
