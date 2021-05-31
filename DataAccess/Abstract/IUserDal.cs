using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        public void UpdateBalance(decimal balance, int cardNumber);
        public string TopVisitor(string month);
         int MonthlyRegistration(string month);
         int YearlyRegistration(string year);

    }
}
