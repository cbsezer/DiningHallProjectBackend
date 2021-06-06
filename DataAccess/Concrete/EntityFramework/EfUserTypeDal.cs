using DataAccess.Abstract;
using Microsoft.ApplicationBlocks.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserTypeDal : IUserTypeDal
    {
        public List<dynamic> UserTypeExpenses()
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                List<dynamic> table = new List<dynamic>();
                DataTable dt = SqlHelper.ExecuteDataset(context.Database.GetConnectionString(), System.Data.CommandType.Text, $"EXEC userTypeExpenses").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var tt = dt.Rows[0];

                    table.Add(tt);
                    return table;
                }
                else
                {
                    return table;
                }
            }
        }

        public string UserTypeInformation(int cardNumber)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                DataTable dt = SqlHelper.ExecuteDataset(context.Database.GetConnectionString(), System.Data.CommandType.Text, $"SELECT TypeDescription FROM UserType INNER JOIN Users ON UserType.TypeNumber = Users.UserType WHERE CardNumber = {cardNumber}").Tables[0];

                return Convert.ToString(dt.Rows[0]["TypeDescription"]);
            }
        }

        public List<dynamic> userTypeList(string type)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                List<dynamic> table = new List<dynamic>();

                DataTable dt = SqlHelper.ExecuteDataset(context.Database.GetConnectionString(), System.Data.CommandType.Text, $"SELECT FirstName + ' ' + LastName as Fullname FROM Users INNER JOIN UserType ON UserType.TypeNumber = Users.UserType WHERE UserType.TypeDescription = '{type}'").Tables[0];

                if (dt.Rows.Count > 0)
                {
                    var tt = dt.Rows[0];

                    table.Add(tt);
                    return table;
                }
                else
                {
                    return table;
                }


            }
        }

        public int UserTypeMonthlySpending(int userType)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                DataTable dt = SqlHelper.ExecuteDataset(context.Database.GetConnectionString(), System.Data.CommandType.Text, $"SELECT COALESCE(SUM(ProcessAmount),0) as Monthly FROM Process INNER JOIN Users ON Process.CardNumber = Users.CardNumber WHERE ProcessTime Like '2021-06%' AND Users.UserType = {userType}").Tables[0];

                return Convert.ToInt32(dt.Rows[0]["Monthly"]);
            }

        }
    }
}
