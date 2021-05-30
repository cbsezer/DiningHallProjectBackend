using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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
        public void EatFood(int cardNumber)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                context.Database.ExecuteSqlRaw("EXEC AddFood {0}", cardNumber);

                context.SaveChanges();
            }
        }

        public void Add(Process entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                context.Database.ExecuteSqlRaw("delete from Process where ProcessID={0}", id);

                context.SaveChanges();
            }
        }


        public Process Get(string sqlCommand)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                return context.Process.FromSqlRaw(sqlCommand).FirstOrDefault();

            }
        }

    
        public List<Process> GetAll(string sqlCommand = null)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                return sqlCommand == null ? context.Process.FromSqlRaw("SELECT * FROM dbo.Process").ToList() : context.Process.FromSqlRaw(sqlCommand).ToList();
            }
        }

    }
}
