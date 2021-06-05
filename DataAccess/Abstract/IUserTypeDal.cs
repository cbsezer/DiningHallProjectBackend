using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserTypeDal
    {
        int UserTypeMonthlySpending(int userType);
        string UserTypeInformation(int cardNumber);
        List<dynamic> UserTypeExpenses();
        List<dynamic> userTypeList(string type);

    }
}
