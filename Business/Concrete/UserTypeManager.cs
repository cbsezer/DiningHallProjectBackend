using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserTypeManager : IUserTypeService
    {
        IUserTypeDal _userTypeDal;

        public UserTypeManager(IUserTypeDal userTypeDal)
        {
            _userTypeDal = userTypeDal;
        }

        public IDataResult<List<dynamic>> UserTypeExpenses()
        {
            return new SuccessDataResult<List<dynamic>>(_userTypeDal.UserTypeExpenses());
        }

        public IDataResult<string> UserTypeInformation(int cardNumber)
        {
            return new SuccessDataResult<string>(_userTypeDal.UserTypeInformation(cardNumber), "Kullanıcı durum bilgisi getirildi");
        }

        public IDataResult<List<dynamic>> UserTypeList(string type)
        {
            return new SuccessDataResult<List<dynamic>>(_userTypeDal.userTypeList(type));
        }

        public IDataResult<int> UserTypeMonthlySpending(int userType)
        {
            return new SuccessDataResult<int>(_userTypeDal.UserTypeMonthlySpending(userType));
        }

     
    }
}
