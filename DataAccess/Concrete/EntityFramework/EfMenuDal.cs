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
    public class EfMenuDal : IMenuDal
    {
        public void Add(Menu entity)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {

                var addedEntity = context.Database.ExecuteSqlRaw("insert into Menus values({0}, {1}, {2}, {3})",
                      entity.MainCourse, entity.Beverage, entity.Dessert, entity.Calorie);

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                context.Database.ExecuteSqlRaw("delete from Menus where MenuID={0}", id);

                context.SaveChanges();
            }
        }

        public Menu Get(string sqlCommand)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                return context.Menus.FromSqlRaw(sqlCommand).FirstOrDefault();

            }
        }

        public List<Menu> GetAll(string sqlCommand = null)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                return sqlCommand == null ? context.Menus.FromSqlRaw("SELECT * FROM dbo.Menus").ToList() : context.Menus.FromSqlRaw(sqlCommand).ToList();
            }
        }

        public Menu MenuDetail(string date)
        {
            throw new NotImplementedException();
        }

            }
}
