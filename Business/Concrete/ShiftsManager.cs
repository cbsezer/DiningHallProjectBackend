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
    public class ShiftsManager : IShiftsService
    {
        IShiftsDal _shiftsDal;

        public ShiftsManager(IShiftsDal shiftsDal)
        {
            _shiftsDal = shiftsDal;
        }
        public IDataResult<int> MonthlyShifts(int staffId)
        {
            return new SuccessDataResult<int>(_shiftsDal.MonthlyShifts(staffId));
        }
    }
}
