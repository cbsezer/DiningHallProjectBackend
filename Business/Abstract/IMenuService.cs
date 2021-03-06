using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMenuService
    {
        IDataResult<List<Menu>> GetAll();
        IResult Add(Menu menu);
        IResult Delete(int id);
        IDataResult<Menu> GetMenuDetail(string date);
        IDataResult<Menu> MenuOfTheDay();


    }
}
