using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var item in userManager.GetAll())
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            //userManager.Add(new User { CardNumber = "18120205031" , FirstName = "Çağla Betül", LastName = "Sezer", Balance = 10, PhoneNumber = "0123456789" });
        }
    }
}
