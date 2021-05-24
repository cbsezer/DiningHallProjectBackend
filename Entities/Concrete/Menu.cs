using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Menu:IEntity
    {
        public int MenuId { get; set; }
        public string MainCourse { get; set; }
        public string Beverage { get; set; }
        public string Dessert { get; set; }
        public int Calorie { get; set; }
    }
}
