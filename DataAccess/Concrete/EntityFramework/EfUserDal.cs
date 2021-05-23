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
    public class EfUserDal : IUserDal
    {
        public void Add(User entity)
        {
            //IDisposable pattern
            using (YemekhaneContext context = new YemekhaneContext())
            {
                var addedEntity = context.Database.ExecuteSqlRaw("insert into Users (CardNumber , FirstName , LastName, Balance, PhoneNumber) values({0}, {1}, {2}, {3}, {4})",
                     entity.CardNumber, entity.FirstName, entity.LastName, entity.Balance, entity.PhoneNumber);

                context.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                return context.Users.FromSqlRaw("SELECT * FROM dbo.Users").ToList();
            }
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
