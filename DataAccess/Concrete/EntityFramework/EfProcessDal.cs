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
    public class EfProcessDal : IProcessDal
    {
        public void Add(Process entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Process entity)
        {
            throw new NotImplementedException();
        }

        public Process Get(Expression<Func<Process, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Process> GetAll(Expression<Func<Process, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Process entity)
        {
            throw new NotImplementedException();
        }
    }
}
