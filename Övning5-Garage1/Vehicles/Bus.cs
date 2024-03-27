using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5_Garage1.Vehicles
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public Bus(string regNo, string color, int nrOfWhells, int numberOfSeats) : base(regNo, color, nrOfWhells)
        {
            NumberOfSeats = numberOfSeats;
        }
        public override string ToString()
        {
            return base.ToString() + $"NumberOfSeats = {NumberOfSeats}";
        }
    }
}
