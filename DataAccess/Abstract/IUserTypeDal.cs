using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserTypeDal
    {
        int UserTypeMonthlySpending(string month, int userType);
        string UserTypeInformation(int cardNumber);
      //  List<string> userTypeList(string type);

    }
}
