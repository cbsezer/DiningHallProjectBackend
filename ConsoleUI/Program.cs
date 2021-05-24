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
            //foreach (var item in userManager.GetAllByBalance(20,25))
            //{
            //    Console.WriteLine(item.FirstName + " " + item.LastName);
            //}

            userManager.Add(new User { FirstName = "Çağla Betül", LastName = "Sezer", PhoneNumber = "0123456789", UserType = 1, Email = "cbsezerr@gmail.com"});
            //userManager.Add(new User { FirstName = "Aleyna", LastName = "Elmas", PhoneNumber = "0123456789", UserType = 1, Email = "a.aleynaelmas@gmail.com" });
            //userManager.Add(new User { FirstName = "Serpil", LastName = "Üstebay", PhoneNumber = "0123456789", UserType = 2, Email = "s.ustebay@medeniyet.edu.tr" });
            //userManager.Add(new User { FirstName = "Emine Aleyna", LastName = "Elmas", PhoneNumber = "0123456789", UserType = 3, Email = "ealeynaelmas@medeniyet.edu.tr" });

            //userManager.Delete("15853353");
            //userManager.Delete("18120205033");
            //userManager.Update(new User { Balance = 21, CardNumber = "18120205033" });

        }
    }
}
