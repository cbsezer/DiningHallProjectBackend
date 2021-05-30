using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;


namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetAllByCategoryId(int id);
        IDataResult<List<User>> GetAllByBalance(decimal min, decimal max);
        IDataResult<User> GetById(int userId);
        IResult Add(User user);
        IDataResult<User> Login(int cardNo, string password);
        IResult Delete(int id);
        IResult UpdateBalance(decimal balance, int cardNumber);
    }
}
