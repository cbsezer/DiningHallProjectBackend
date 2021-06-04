using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserTypeService
    {
        IDataResult<int> UserTypeMonthlySpending(string month, int userType);
        IDataResult<string> UserTypeInformation(int cardNumber);

        IDataResult<List<dynamic>> UserTypeExpenses();


    }
}
