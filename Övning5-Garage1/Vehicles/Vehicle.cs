using Övning5_Garage1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5_Garage1.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int NrOfWheels { get; set; }

        public Vehicle(string regNo, string color, int nrOfWhells)
        {
            RegistrationNumber = regNo;
            Color = color;
            NrOfWheels = nrOfWhells;
        }

        public override string ToString()
        {
            return $"Vehicle: Type={GetType().Name}, RegNo= {RegistrationNumber}, Color= {Color}, NrOfWheels= {NrOfWheels}, ";
        }
    }
}

    