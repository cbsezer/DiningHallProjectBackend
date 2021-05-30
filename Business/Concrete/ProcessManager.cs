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

        public IDataResult<Process> GetUserMonthlySpending(int userId, string month)
        {

            return new SuccessDataResult<Process>(_processDal.Get($"SELECT SUM(ProcessAmount) AS Spending FROM Process WHERE ProcessTime Like '2021-{month}%' AND CardNumber = {userId}"));
        }
    }
}
