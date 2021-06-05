using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProcessService
    {
        IResult EatFood(int cardNumber);
        IDataResult<List<Process>> GetAll();
        IResult Delete(int id);
        IDataResult<int> GetUserMonthlySpending(int userId, string month);
        IDataResult<int> GetMonthlyGain(string month);
        IDataResult<int> GetYearlyGain();
        

    }
}
