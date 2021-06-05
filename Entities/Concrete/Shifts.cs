using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Keyless]
    public class Shifts : IEntity
    {
        public int StaffId { get; set; }
        public DateTime ShiftDate { get; set; }
    }
}
