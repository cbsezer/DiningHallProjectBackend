using Business.Abstract;
using Business.Constants;
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
    public class MenuManager : IMenuService
    {
        IMenuDal _menuDal;

        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }

        public IResult Add(Menu menu)
        {
            _menuDal.Add(menu);
            return new SuccessResult(Messages.MenuAdded);
        }

        public IResult Delete(int id)
        {
            _menuDal.Delete(id);
            return new SuccessResult(Messages.MenuDeleted);
        }

        public IDataResult<List<Menu>> GetAll()
        {
            return new SuccessDataResult<List<Menu>>(_menuDal.GetAll(), Messages.MenusListed);
        }
    }
}
