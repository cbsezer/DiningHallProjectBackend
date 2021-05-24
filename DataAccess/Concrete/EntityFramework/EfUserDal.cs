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
                
                var random = new Random();
                string s = string.Empty;
                for (int i = 0; i < 7; i++)
                {
                    s = String.Concat(s, random.Next(10).ToString());
                }
                if (entity.UserType == 1)
                {
                     entity.CardNumber = "1" + s;
                }else if(entity.UserType == 2)
                {
                    entity.CardNumber = "2" + s;
                }
                else if (entity.UserType == 3)
                {
                    entity.CardNumber = "3" + s;
                }
                //aynı isim mail ve telefon numarası eşleşirse sistemde kullanıcıyı kaydetme
                var addedEntity = context.Database.ExecuteSqlRaw("insert into Users values({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                      entity.CardNumber, entity.FirstName, entity.LastName, entity.Email, entity.UserType, 0, entity.PhoneNumber);

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("imuyemekhane@gmail.com");
                mail.To.Add(entity.Email);
                mail.Subject = "Yemekhane Kart Başvurusu";

                mail.Body = $"\nMerhaba {entity.FirstName} {entity.LastName}.\n\nİstanbul Medeniyet Üniversitesi yemekhane kart başvurun onaylandı. \n\nKart numaran: {entity.CardNumber}";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("imuyemekhane@gmail.com", "yemekhane123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);


                context.SaveChanges();
            }
        }
        public void Delete(string cardNumber)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
               context.Database.ExecuteSqlRaw("delete from Users where CardNumber={0}", cardNumber);

                context.SaveChanges();
            }

        }

    

        public User Get(string sqlCommand)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll(string sqlCommand = null)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                //return context.Users.FromSqlRaw("SELECT * FROM dbo.Users").ToList();
                return sqlCommand == null ? context.Users.FromSqlRaw("SELECT * FROM dbo.Users").ToList() : context.Users.FromSqlRaw(sqlCommand).ToList();
            }
        }

        public void Update(User entity)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                context.Database.ExecuteSqlRaw("update Users set Balance = {0} where Id={1}", entity.Balance, entity.CardNumber);

                context.SaveChanges();
            }
        }
    }
}
