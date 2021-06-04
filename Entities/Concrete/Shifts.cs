using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Shifts : IEntity
    {
        [Key] public int StaffId { get; set; }
        public DateTime ShiftDate { get; set; }
    }
}
