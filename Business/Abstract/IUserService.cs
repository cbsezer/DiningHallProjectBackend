using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetAllByCategoryId(int id);
        IDataResult<List<User>> GetAllByBalance(decimal min, decimal max);
        IDataResult<User> GetById(int userId);
        IResult Add(User user);
        IResult Delete(string id);
        IResult Update(User user);
    }
}
