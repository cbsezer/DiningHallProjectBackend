using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Process : IEntity
    {
        public string ProcessId { get; set; }
        public string CardNumber { get; set; }
        public DateTime ProcessTime { get; set; }
        public decimal ProcessAmount { get; set; }
    }


    public class Test1 : IEntity
    {
        public int kolon1 { get; set; }
       
    }
}
