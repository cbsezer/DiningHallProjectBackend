using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : IUserDal
    {

        public void Add(User entity)
        {
            //IDisposable pattern
            using (YemekhaneContext context = new YemekhaneContext())
            {

                //aynı isim mail ve telefon numarası eşleşirse sistemde kullanıcıyı kaydetme
                context.Database.ExecuteSqlRaw("IF( exists (select * from  Users where Email != {2} and PhoneNumber != {6})) BEGIN insert into Users values({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}) END",
                       entity.FirstName, entity.LastName, entity.Email, entity.PasswordSalt, entity.UserType, 0, entity.PhoneNumber, DateTime.Now.ToString());

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

        public List<dynamic> MonthlyExpense()
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                List<dynamic> table = new List<dynamic>();

                DataTable dt = SqlHelper.ExecuteDataset(context.Database.GetConnectionString(), System.Data.CommandType.Text, "EXEC monthlyExpense 6").Tables[0];

                var tt = dt.Rows[0];

                table.Add(tt);
                return table;
            }
        }

        public int MonthlyRegistration(string month)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                DataTable dt = SqlHelper.ExecuteDataset(context.Database.GetConnectionString(), System.Data.CommandType.Text, $"SELECT COUNT(*) AS Registration FROM Users WHERE RegistrationDate Like '2021-0{month}%'").Tables[0];

                return Convert.ToInt32(dt.Rows[0]["Registration"]);
            }
        }



        public List<dynamic> TopVisitor()
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                List<dynamic> table = new List<dynamic>();

                DataTable dt = SqlHelper.ExecuteDataset(context.Database.GetConnectionString(), System.Data.CommandType.Text, "EXEC topVisitor 6").Tables[0];

                var tt = dt.Rows[0];

                table.Add(tt);
                return table;
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

        public int YearlyRegistration()
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                DataTable dt = SqlHelper.ExecuteDataset(context.Database.GetConnectionString(), System.Data.CommandType.Text, "SELECT COUNT(*) AS Registration FROM Users WHERE RegistrationDate Like '2021%'").Tables[0];

                return Convert.ToInt32(dt.Rows[0]["Registration"]);
            }
        }

        public List<dynamic> TopSpender()
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                List<dynamic> table = new List<dynamic>();
                DataTable dt = SqlHelper.ExecuteDataset(context.Database.GetConnectionString(), System.Data.CommandType.Text, "EXEC topSpender 6").Tables[0];
                var tt = dt.Rows[0];

                table.Add(tt);
                return table;
            }
        }

        public List<dynamic> MonthlyVisitors(string date)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                List<dynamic> table = new List<dynamic>();
                DataTable dt = SqlHelper.ExecuteDataset(context.Database.GetConnectionString(), System.Data.CommandType.Text, $"EXEC monthlyVisitors '{date}'").Tables[0];
                var tt = dt.Rows[0];

                table.Add(tt);
                return table;
            }
        }
    }
}
