using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5_Garage1.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }
        public Motorcycle(string regNo, string color, int nrOfWhells, int cylinderVolume) : base(regNo, color, nrOfWhells)
        {
            CylinderVolume = cylinderVolume;
        }
        public override string ToString()
        {
            return base.ToString() + $"CylinderVolume= {CylinderVolume}";
        }
    }
}
