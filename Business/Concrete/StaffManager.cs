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
    public class StaffManager : IStaffService
    {

        IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public IResult Add(Staff staff)
        {
            if (staff.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.UserNameInvalid);
            }
            _staffDal.Add(staff);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(int id)
        {
            _staffDal.Delete(id);
            return new SuccessResult(Messages.StaffDeleted);
        }

        public IDataResult<List<Staff>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Staff>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Staff>>(_staffDal.GetAll(), Messages.StaffListed);
        }

        public IDataResult<Staff> StaffOfTheDay()
        {
            return new SuccessDataResult<Staff>(_staffDal.Get("SELECT * FROM Staff Where Staff.ShiftDate = CONVERT(date, GETDATE())"));
        }
    }
}
