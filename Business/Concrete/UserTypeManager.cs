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

        public IDataResult<string> UserTypeInformation(int cardNumber)
        {
            return new SuccessDataResult<string>(_userTypeDal.UserTypeInformation(cardNumber), "Kullanıcı durum bilgisi getirildi");
        }

        public IDataResult<List<string>> UserTypeList(string type)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> UserTypeMonthlySpending(string month, int userType)
        {
            return new SuccessDataResult<int>(_userTypeDal.UserTypeMonthlySpending(month, userType));
        }
    }
}
