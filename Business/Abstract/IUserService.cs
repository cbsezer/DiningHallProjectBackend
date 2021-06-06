using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using System.Data;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetAllByBalance(decimal min, decimal max);
        IDataResult<User> GetById(int userId);
        IDataResult<int> MonthlyRegistration(string month);
        IDataResult<int> YearlyRegistration();
        IDataResult<List<dynamic>> TopVisitor();
        IDataResult<List<dynamic>> WeeklyCalories(string date, int cardNumber);
        IDataResult<List<dynamic>> TopSpender();
        IDataResult<List<dynamic>> MonthlyExpense();
        IDataResult<List<dynamic>> MonthlyVisitors(string date);
        IResult Add(User user);
        IDataResult<User> Login(int cardNo, string password);
        IResult Delete(int id);
        IResult UpdateBalance(decimal balance, int cardNumber);
        //IDataResult<User> MostOutgoingUser();
    }
}
