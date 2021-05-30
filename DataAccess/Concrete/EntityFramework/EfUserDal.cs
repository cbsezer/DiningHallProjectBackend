using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : IUserDal
    {


        //List<UserDetailDTO> GetUserDetails()
        //{
        //    using (YemekhaneContext context = new YemekhaneContext())
        //    {
        //        //    //joinli sorgular burada atılacak

        //        var result = from p in context.Products
        //                     join c in context.Categories
        //                     on p.CategoryId equals c.CategoryId
        //                     select new ProductDetailDto
        //                     {
        //                         ProductId = p.ProductId,
        //                         ProductName = p.ProductName,
        //                         CategoryName = c.CategoryName,
        //                         UnitsInStock = p.UnitsInStock
        //                     };
        //        return result.ToList();
        //    }
        //}
        public void Add(User entity)
        {
            //IDisposable pattern
            using (YemekhaneContext context = new YemekhaneContext())
            {

                 //aynı isim mail ve telefon numarası eşleşirse sistemde kullanıcıyı kaydetme
                context.Database.ExecuteSqlRaw("IF( exists (select * from  Users where Email != {2} and PhoneNumber != {6})) BEGIN insert into Users values({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}) END",
                       entity.FirstName, entity.LastName, entity.Email, entity.PasswordSalt, entity.UserType, 0, entity.PhoneNumber, DateTime.Now);

                var sendMail = context.Users.FromSqlRaw("User_INSERT_Notification");
                context.SaveChanges();
            }
        }
        public void Delete(int cardNumber)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
               context.Database.ExecuteSqlRaw("DELETE from Process WHERE CardNumber={0} DELETE from Users WHERE CardNumber={0} ", cardNumber);

                context.SaveChanges();
            }

        }

        public User Get(string sqlCommand)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                return context.Users.FromSqlRaw(sqlCommand).FirstOrDefault();

            }
        }

        public List<User> GetAll(string sqlCommand = null)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                //return context.Users.FromSqlRaw("SELECT * FROM dbo.Users").ToList();
                return sqlCommand == null ? context.Users.FromSqlRaw("SELECT * FROM dbo.Users").ToList() : context.Users.FromSqlRaw(sqlCommand).ToList();
            }
        }

        public void UpdateBalance(decimal balance, int cardNumber)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {

                context.Database.ExecuteSqlRaw("update Users set Balance = Balance + {0} where CardNumber={1}", balance, cardNumber);

                context.SaveChanges();
            }
        }

           }
}
