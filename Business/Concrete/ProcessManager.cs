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
    public class ProcessManager : IProcessService
    {
        IProcessDal _processDal;

        public ProcessManager(IProcessDal processDal)
        {
            _processDal = processDal;
        }

        public IResult Delete(int id)
        {
            _processDal.Delete(id);
            return new SuccessResult(Messages.ProcessDeleted);
        }

        public IResult EatFood(int cardNumber)
        {
            _processDal.EatFood(cardNumber);
            return new SuccessResult(Messages.ProcessAdded);
        }

        public IDataResult<List<Process>> GetAll()
        {
            return new SuccessDataResult<List<Process>>(_processDal.GetAll(), Messages.ProcessListed);

        }

        public IDataResult<int> GetMonthlyGain(string month)
        {
            return new SuccessDataResult<int>(_processDal.GetMonthlyGain(month));
        }

        public IDataResult<int> GetUserMonthlySpending(int userId, string month)
        {

            return new SuccessDataResult<int>(_processDal.GetUserMonthlySpending(userId, month));

        }

        public IDataResult<int> GetYearlyGain(string year)
        {
            return new SuccessDataResult<int>(_processDal.GetYearlyGain(year));
        }
    }
}
