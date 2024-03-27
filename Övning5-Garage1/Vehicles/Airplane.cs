using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5_Garage1.Vehicles
{
    public class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }
        public Airplane(string regNo, string color, int nrOfWhells, int numberOfEngines) : base(regNo, color, nrOfWhells)
        {
            NumberOfEngines = numberOfEngines;
        }
        public override string ToString()
        {
            return base.ToString() + $"NumberOfEngines= {NumberOfEngines}";
        }
    }
}
