using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5_Garage1.Vehicles
{
    public class Boat : Vehicle
    {
        public double Length { get; set; }
        public Boat(string regNo, string color, int nrOfWhells, double length) : base(regNo, color, nrOfWhells)
        {
            Length = length;
        }
        public override string ToString()
        {
            return base.ToString() + $"Length= {Length}";
        }
    }
}
