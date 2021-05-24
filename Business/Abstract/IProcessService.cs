using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProcessService
    {
        List<Process> GetAll();
        List<Process> GetAllByCategoryId(int id);
        List<Process> GetAllByBalance(decimal min, decimal max);
        void Add(Process process);
        void Delete(string id);
        void Update(Process process);
    }
}
