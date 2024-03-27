using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Övning5_Garage1.Interface;
using Övning5_Garage1.Vehicles;

namespace Övning5_Garage1.Garage
{
    public class GarageHandler : IHandler
    {

        //public Garage<Vehicle>? garage;
        public Garage<Vehicle> garage = null!;

        public void CreateParkingSpots(int parkingSize)
        {
            garage = new Garage<Vehicle>(parkingSize);
        }


        public bool AddVehicle(Vehicle vehicle)
        {
            if (garage.CheckIsParkingFull())
            {
                Console.WriteLine("Cannot add more vehicles: Garage is full.");
                return false;
            }

            return garage.AddItem(vehicle);
        }

        public bool AddAirplane(string regNo, string color, int nrOfWheel, int numberOfEngines)
        {
            return AddVehicle(new Airplane(regNo, color, nrOfWheel, numberOfEngines));
        }

        public bool AddMotorcycle(string regNo, string color, int nrOfWheel, int cylinderVolume)
        {
            return AddVehicle(new Motorcycle(regNo, color, nrOfWheel, cylinderVolume));
        }

        public bool AddCar(string regNo, string color, int nrOfWheel, string fuelType)
        {
            return AddVehicle(new Car(regNo, color, nrOfWheel, fuelType));
        }

        public bool AddBus(string regNo, string color, int nrOfWheel, int numberOfSeats)
        {
            return AddVehicle(new Bus(regNo, color, nrOfWheel, numberOfSeats));
        }

        public bool AddBoat(string regNo, string color, int nrOfWheel, double length)
        {
            return AddVehicle(new Boat(regNo, color, nrOfWheel, length));
        }



        public string ListAllParkedVehicles()
        {
            if (garage == null || !garage.Any())
            {
                return "Garage is empty.";
            }

            var listVehicles = new StringBuilder();
            int i = 1;

            foreach (Vehicle item in garage)
            {
                listVehicles.AppendLine($"{i}. {item}");
                i++;
            }

            return listVehicles.ToString();
        }


        public int CurrentNumberOfVehiclesInGarage()
        {
            int numberOfCars = garage.NumberOfVehiclesInParking;
            return numberOfCars;
        }

        public bool RemoveVehicleFrom(int vehicleToRemove)
        {
            if (garage.RemoveItem(vehicleToRemove) == true)
            {
                return true;
            }
            return false;

        }

        public string FindVehiclByRegistrationNumber(string registrationNumber)
        {

            List<Vehicle> matchedRegNumber = new List<Vehicle>();

            foreach (Vehicle item in garage)
            {
                if (item != null && item.RegistrationNumber != null &&
                    string.Equals(item.RegistrationNumber, registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    matchedRegNumber.Add(item);
                }
            }

            if (matchedRegNumber.Count > 0)
            {
                string result = $"Great! System found vehicle with reg no: {registrationNumber}:\n" +
                                string.Join("\n", matchedRegNumber.Select(item => item.ToString()));

                return result;
            }
            else
            {
                return $"No vehicle with reg no: {registrationNumber}.";
            }

        }



        public string ListAllParkedVehiclesAndType()
        {


            Dictionary<string, int> vehicleTypeAndCount = new Dictionary<string, int>();

            foreach (Vehicle item in garage)
            {

                string typeName = item.GetType().Name;

                if (vehicleTypeAndCount.ContainsKey(typeName))
                {
                    vehicleTypeAndCount[typeName]++;
                }
                else
                {
                    vehicleTypeAndCount.Add(typeName, 1);
                }
            }


            StringBuilder resultStringBuilder = new StringBuilder();

            foreach (KeyValuePair<string, int> entry in vehicleTypeAndCount)
            {
                resultStringBuilder.AppendLine($"{entry.Key}: {entry.Value}");
            }

            return resultStringBuilder.ToString();

        }

        public void PopulateParkingWithData()
        {
            AddAirplane("AAA651", "red", 16, 2);
            AddAirplane("BBB651", "green", 16, 1);
            AddCar("CCC651", "green", 4, "diesel");
            AddCar("DDD651", "red", 4, "diesel");
            AddBus("RRR478", "red", 6, 50);
            AddBus("RYW478", "green", 6, 12);

        }

        public string FindVehicleByProperties(string colorToFind, int? wheelsToFind, string typeToFind)
        {

            StringBuilder resultStringBuilder = new StringBuilder();
            bool isMatch = false;

            foreach (Vehicle item in garage)
            {
                bool colorMatches = string.IsNullOrEmpty(colorToFind) || string.Equals(item.Color, colorToFind, StringComparison.OrdinalIgnoreCase);
                bool wheelsMatches = !wheelsToFind.HasValue || item.NrOfWheels == wheelsToFind.Value;
                bool typeMatches = string.IsNullOrEmpty(typeToFind) || string.Equals(item.GetType().Name, typeToFind, StringComparison.OrdinalIgnoreCase);

                if (colorMatches && wheelsMatches && typeMatches)
                {
                    resultStringBuilder.AppendLine($"Found! match vehicle: {item.ToString()}");
                    isMatch = true;
                }
            }

            if (!isMatch)
            {
                return "No matching vehicle";
            }

            return resultStringBuilder.ToString();
        }

        public bool RegistrationNumberExists(string regNo)
        {
            {
                foreach (Vehicle item in garage)
                {
                    if (item != null && item.RegistrationNumber != null &&
                        string.Equals(item.RegistrationNumber, regNo, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

                return false;
            }

        }

        public bool IsParkingFull()
        {
            //ToDo: check it
            return garage.CheckIsParkingFull();
        }


    }
}
