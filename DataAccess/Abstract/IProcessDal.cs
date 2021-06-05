using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProcessDal : IEntityRepository<Process>
    {
        void EatFood(int cardNumber);

        int GetUserMonthlySpending(int userId, string month);

        int GetMonthlyGain(string month);
        int GetYearlyGain();


    }
}
