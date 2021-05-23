using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class YemekhaneContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-R8F85FB;Database=DiningHall;Trusted_Connection=true");
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Food> Foods { get; set; }
        //public DbSet<Process> Processes { get; set; }
        //public DbSet<UserType> UserTypes { get; set; }
    }
}
