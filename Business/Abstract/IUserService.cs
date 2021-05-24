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
        List<User> GetAll();
        List<User> GetAllByCategoryId(int id);
        List<User> GetAllByBalance(decimal min, decimal max);
        IResult Add(User user);
        IResult Delete(string id);
        IResult Update(User user);
    }
}
