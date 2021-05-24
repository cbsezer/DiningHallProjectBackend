using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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



        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public List<User> GetAllByBalance(decimal min, decimal max)
        {
            return _userDal.GetAll($"select * from Users where Balance between {min} and {max}");
        }

        public List<User> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }       

        IResult IUserService.Add(User user)
        {
          
            _userDal.Add(user);
            return new Result(true, "Kullanıcı eklendi");
        }

        IResult IUserService.Delete(string id)
        {
            _userDal.Delete(id);
            return new Result(true, "Kullanıcı silindi");

        }

        IResult IUserService.Update(User user)
        {
            _userDal.Update(user);
            return new Result(true, "Kullanıcı güncellendi");

        }
    }
}
