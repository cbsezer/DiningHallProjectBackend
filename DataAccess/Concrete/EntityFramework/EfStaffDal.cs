using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStaffDal : IStaffDal
    {
        public void Add(Staff entity)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {

                var addedEntity = context.Database.ExecuteSqlRaw("insert into Staff values({0}, {1})",
                      entity.FirstName, entity.LastName);

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
           
                context.Database.ExecuteSqlRaw("delete from Shifts where StaffId={0} delete from Staff where StaffId={0}", id);

                context.SaveChanges();
            }
        }

        public Staff Get(string sqlCommand)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                return context.Staff.FromSqlRaw(sqlCommand).FirstOrDefault();

            }
        }

        public List<Staff> GetAll(string sqlCommand = null)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                return sqlCommand == null ? context.Staff.FromSqlRaw("SELECT * FROM dbo.Staff").ToList() : context.Staff.FromSqlRaw(sqlCommand).ToList();
            }
        }

        public void Update(Staff entity)
        {
            throw new NotImplementedException();
        }

    }
}
