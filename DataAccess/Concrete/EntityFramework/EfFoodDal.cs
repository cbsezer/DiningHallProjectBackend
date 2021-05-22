using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFoodDal : IFoodDal
    {
        public void Add(Food entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Food entity)
        {
            throw new NotImplementedException();
        }

        public Food Get(Expression<Func<Food, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Food> GetAll(Expression<Func<Food, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Food entity)
        {
            throw new NotImplementedException();
        }
    }
}
