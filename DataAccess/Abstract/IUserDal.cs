using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        public void UpdateBalance(decimal balance, int cardNumber);
        List<dynamic> TopVisitor();
        List<dynamic> MonthlyExpense();
        List<dynamic> MonthlyVisitors(string date);
        List<dynamic> WeeklyCalories(string date, int cardNumber);
        List<dynamic> TopSpender();
        int MonthlyRegistration(string month);
        int YearlyRegistration();

    }
}
