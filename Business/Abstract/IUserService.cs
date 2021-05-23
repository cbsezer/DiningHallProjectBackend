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
        List<User> GetAllBByUnitPrice(decimal min, decimal max);

        void Add(User user);
    }
}
