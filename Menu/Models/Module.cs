using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA_MenuApp.Models
{
    public class Module
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Grade { get; set; }
        public double GradePoint { get; set; }
        public double CreditPoint { get; set; }
        public Module(int id, string name, double creditPoint)
        {
            Id = id;
            Name = name;
            CreditPoint = creditPoint;
            GradePoint = 0;
        }
        
    }

}
