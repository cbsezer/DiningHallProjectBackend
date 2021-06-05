using DataAccess.Abstract;
using Entities.Concrete;
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
    public class EfShiftsDal : IShiftsDal
    {
        public int MonthlyShifts(int staffId)
        {
            using (YemekhaneContext context = new YemekhaneContext())
            {
                DataTable dt = SqlHelper.ExecuteDataset(context.Database.GetConnectionString(), System.Data.CommandType.Text, $"SELECT COUNT(*) as NumberOfShifts FROM Shifts WHERE ShiftDate Like'2021-06%' AND StaffId = {staffId}").Tables[0];

                return Convert.ToInt32(dt.Rows[0]["NumberOfShifts"]);
            }
        }
    }
}
