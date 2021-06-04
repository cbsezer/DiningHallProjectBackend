using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        public void UpdateBalance(decimal balance, int cardNumber);
         string TopVisitor(string month);
        List<dynamic> TopSpender(string month);
        int MonthlyRegistration(string month);
         int YearlyRegistration(string year);

    }
}
