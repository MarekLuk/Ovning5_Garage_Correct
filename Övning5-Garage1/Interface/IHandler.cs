using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5_Garage1.Interface
{
    public interface IHandler
    {
        void CreateParkingSpots(int parkingsSize);
        bool IsParkingFull();
        bool AddAirplane(string regNo, string color, int nrOfWhell, int numberOfEngines);
        bool AddMotorcycle(string regNo, string color, int nrOfWhells, int cylinderVolume);
        bool AddCar(string regNo, string color, int nrOfWhells, string fuelType);
        bool AddBus(string regNo, string color, int nrOfWhells, int numberOfSeats);
        bool AddBoat(string regNo, string color, int nrOfWhells, double length);
        string ListAllParkedVehicles();

        int CurrentNumberOfVehiclesInGarage();
        bool RemoveVehicleFrom(int vehicleToRemove);
        string ListAllParkedVehiclesAndType();
        string FindVehiclByRegistrationNumber(string registrationNumber);
        void PopulateParkingWithData();
        string FindVehicleByProperties(string colorToFind, int? wheelsToFind, string typeToFind);
        bool RegistrationNumberExists(string regNo);

    }
}
