using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            this._userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<List<User>> GetAllByBalance(decimal min, decimal max)
        {
              return new SuccessDataResult<List<User>>(_userDal.GetAll($"select * from Users where Balance between {min} and {max}"), Messages.UsersListed);
        }

        public IDataResult<List<User>> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get($"Select * from Users Where CardNumber={userId}"));
        }

        public IResult Add(User user)
        {
          if(user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.UserNameInvalid);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(int id)
        {
            _userDal.Delete(id);
            return new SuccessResult(Messages.UserDeleted);

        }


        public IResult UpdateBalance(decimal balance, int cardNumber)
        {
            _userDal.UpdateBalance(balance, cardNumber);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<User> Login(int cardNo, string password)
        {
            return new SuccessDataResult<User>(_userDal.Get($"Select * from Users Where CardNumber={cardNo} and PasswordSalt={password}"));
        }

        public IDataResult<int> MonthlyRegistration(string month)
        {
            return new SuccessDataResult<int>(_userDal.MonthlyRegistration(month));
        }

        public IDataResult<int> YearlyRegistration(string year)
        {
            return new SuccessDataResult<int>(_userDal.YearlyRegistration(year));
        }

        public IDataResult<string> TopVisitor(string month)
        {
            return new SuccessDataResult<string>(_userDal.TopVisitor(month), "En çok giden kullanıcı");
        }

        public IDataResult<List<dynamic>> TopSpender(string month)
        {
            return new SuccessDataResult<List<dynamic>> (_userDal.TopSpender(month));
        }
    }
}
