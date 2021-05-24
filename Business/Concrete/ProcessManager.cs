using Business.Abstract;
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

        public void Add(Process process)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Process> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Process> GetAllByBalance(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public List<Process> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Process process)
        {
            throw new NotImplementedException();
        }
    }
}
