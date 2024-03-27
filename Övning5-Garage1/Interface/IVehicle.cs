using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5_Garage1.Interface
{
    public interface IVehicle
    {
            string RegistrationNumber { get; set; }
            string Color { get; set; }
            int NrOfWheels { get; set; }
    }
}
