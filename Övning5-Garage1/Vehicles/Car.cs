using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5_Garage1.Vehicles
{
    public class Car : Vehicle
    {
        public string FuelType { get; set; }
        public Car(string regNo, string color, int nrOfWhells, string fuelType) : base(regNo, color, nrOfWhells)
        {
            FuelType = fuelType;
        }
        public override string ToString()
        {
            return base.ToString() + $"FuelType= {FuelType}";
        }
    }
}
