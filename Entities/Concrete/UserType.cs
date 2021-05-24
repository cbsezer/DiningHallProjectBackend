using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserType : IEntity
    {
        public int TypeNumber { get; set; }
        public string TypeDescription { get; set; }
    }
}
