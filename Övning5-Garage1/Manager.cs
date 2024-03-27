using Övning5_Garage1.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Övning5_Garage1
{
    internal class Manager
    {

        private  IUI uiManager;

        private IHandler commandHandler;

        public Manager(IUI uiManager , IHandler commandHandler) 
        {
            this.uiManager = uiManager;
            this.commandHandler = commandHandler;
        }
             
    

        internal void Run() 
        {
            Initializer();
            StartGarage();

        }

        private void StartGarage()
        {
           
            while (true)
            {
                string inputData = uiManager.GetInput(MainMenu());
              


                switch (inputData.ToUpper())
                {
                    case "1":
                        ListVehicles();
                        break;
                    case "2":
                        ListVehiclesTypesAndHowMany();
                        break;
                    case "3":
                        AddVehicle();
                        break;
                    case "4":
                        RemoveVehicle();
                        break;
                    case "5":
                        FindVehicleRegNumber();
                        break;
                    case "6":
                        FindVehicleCharacteristics();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        uiManager.MessageLine("Enter valid input:");
                        break;

                }

            }     
            
        }

        private void PopulateParking()
        {
            commandHandler.PopulateParkingWithData();
            uiManager.MessageLine("Populate with data. Done!");
        }



        private void FindVehicleCharacteristics()
        {
            string listOfAllParkedVehicles = commandHandler.ListAllParkedVehicles();
            if (listOfAllParkedVehicles == "Garage is empty.")
            {
                uiManager.MessageLine("You can't find any vehicle because garage is empty!");
                return;
            }

           
            VehicleType vehicleChoice = GetUserChoiceForVehicleType();
            string typeToFind = vehicleChoice == VehicleType.None ? "" : vehicleChoice.ToString();

            string colorToFind = GetUserChoiceForCharacteristic("color");
            int? wheelsToFind = GetUserChoiceForCharacteristic("wheels number", true);

            var searchResults = commandHandler.FindVehicleByProperties(colorToFind, wheelsToFind, typeToFind);
            DisplaySearchResults(searchResults, colorToFind, typeToFind, wheelsToFind);
        }
     

        private VehicleType GetUserChoiceForVehicleType()
        {
            uiManager.MessageLine("Do you want to specify a vehicle type? (y/n): ");           
            string choice = uiManager.ReadMessage();
            if (choice?.Trim().ToLower() == "y")
            {
                uiManager.MessageLine("Select a vehicle type:");
                uiManager.MessageLine("1. Airplane");
                uiManager.MessageLine("2. Motorcycle");
                uiManager.MessageLine("3. Car");
                uiManager.MessageLine("4. Bus");
                uiManager.MessageLine("5. Boat");
                uiManager.MessageLine("Enter the number corresponding to the vehicle type, or 0 to skip:");

               
                string input = uiManager.ReadMessage();
              
                if (int.TryParse(input, out int vehicleTypeNum) && Enum.IsDefined(typeof(VehicleType), vehicleTypeNum))
                {
                    return (VehicleType)vehicleTypeNum;
                }
                else
                {
                    uiManager.MessageLine("Invalid selection. Defaulting to no specific type.");
                }
            }
            else if (choice?.Trim().ToLower() == "n")
            {
                return VehicleType.None;
            }

            return VehicleType.None;
        }


        private string GetUserChoiceForCharacteristic(string characteristic)
        {
            if (uiManager.GetConfirmation($"Find vehicle by {characteristic}?"))
            {
                return uiManager.GetInput($"Enter {characteristic}:");
            }
            return ""; 
        }

        private int? GetUserChoiceForCharacteristic(string characteristic, bool isNumeric)
        {
            if (!isNumeric || !uiManager.GetConfirmation($"Find vehicle by {characteristic}?")) return null;

            while (true)
            {
                string input = uiManager.GetInput($"Enter {characteristic}:");
                if (int.TryParse(input, out int result)) return result;

                uiManager.MessageLine("Invalid input. Please enter a valid number.");
            }
        }

        private void DisplaySearchResults(string results, string color, string type, int? wheels)
        {
            string criteria = $"Criteria - Color: {color ?? "any"}, Type: {type ?? "any"}, Wheels: {wheels?.ToString() ?? "any"}";
            uiManager.MessageLine(criteria);
            uiManager.MessageLine(string.IsNullOrEmpty(results) ? "No vehicles found matching the criteria." : results);
        }

            



        private void FindVehicleRegNumber()
        {
            string listOfAllParkedVehicles = commandHandler.ListAllParkedVehicles();
            if (listOfAllParkedVehicles == "Garage is empty.")
            {
                uiManager.MessageLine("You can't find any vehicle because garage is empty!");
                return;
            }
            string registrationNumber = uiManager.GetInput("Find a specific vehicle by registraion number:");
            string vehicleToFind=commandHandler.FindVehiclByRegistrationNumber(registrationNumber);
            uiManager.MessageLine(vehicleToFind);

        }

        private void RemoveVehicle()
        {
            
            string listOfAllParkedVehicles = commandHandler.ListAllParkedVehicles();
            if (listOfAllParkedVehicles == "Garage is empty.")
            {
                uiManager.MessageLine(listOfAllParkedVehicles);
                return;

            }
            uiManager.MessageLine("List of vehicle : ");
            uiManager.MessageLine(listOfAllParkedVehicles);
            uiManager.MessageLine("Enter number of vehicle to remove or enter 0 to cancel:");

            int vehicleToRemove = uiManager.GetNumberInput("");

            if (vehicleToRemove == 0)
            {
                uiManager.MessageLine("Operation cancelled.");
                return; 
            }

            bool validInput = false;
            while(!validInput) 
            {
                
               
                if (vehicleToRemove < 1|| vehicleToRemove > commandHandler.CurrentNumberOfVehiclesInGarage())
                {
                    uiManager.MessageLine("Invalid input");
                    vehicleToRemove = uiManager.GetNumberInput("");

                }
                else
                {
                    validInput = true;
                }

            }

            bool removedSuccessfully = commandHandler.RemoveVehicleFrom(vehicleToRemove-1);
            if (removedSuccessfully)
            {
                uiManager.MessageLine($"Vehicle number {vehicleToRemove} has been successfully removed.");
            }
            else
            {              
                uiManager.MessageLine("An error occurred while attempting to remove the vehicle. Please try again.");
            }

        }

     

        private void ListVehiclesTypesAndHowMany()
        {
            uiManager.MessageLine("List of all parked vehicles and type");
            string listOfAllParkedVehiclesAndType = commandHandler.ListAllParkedVehiclesAndType();
            uiManager.MessageLine(listOfAllParkedVehiclesAndType);
        }

        private void ListVehicles()
        {
            uiManager.MessageLine("List of all parked vehicles: \n");
            string listOfAllParkedVehicles = commandHandler.ListAllParkedVehicles();
            uiManager.MessageLine(listOfAllParkedVehicles);
        }

        private void Initializer()
        {
            uiManager.MessageLine("Welcome to Garage");
            int parkingsSize = uiManager.GetSizeParking("Enter capacity of cars in parking");

            commandHandler.CreateParkingSpots(parkingsSize);
         
            bool isValid = false;
           
            do
            {
                string populateChoice= uiManager.GetInput("Populate parking from begining (y/n): ");

                if (populateChoice.ToLower() == "y")
                {
                    isValid = true;
                    PopulateParking();



                }
                else if (populateChoice.ToLower() == "n")
                {
                    isValid = true;
                }
                else
                {
                    uiManager.MessageLine("Invalid input. Please enter 'y' for yes or 'n' for no.");

                }
            } while (!isValid);         

        }

        private string MainMenu()
        {
            return ($"Select option: " 
                +"\n1. List all parked vehicles"
                +"\n2. List vehicle types and how many of each are in garage " 
                +"\n3. Add vehicle to garage " 
                +"\n4. Remove vehicle from garage " 
                +"\n5. Find vehicle by registration number " 
                +"\n6. Find vehicle by characteristics "          

                + "\n0. To exit");
        }


        enum VehicleType { None = 0, Airplane, Motorcycle, Car, Bus, Boat }


        private VehicleType GetVehicleTypeFromUser()
        {
            while (true)
            {
                uiManager.MessageLine("Enter type of vehicle: " +
                    "\n1. Airplane" +
                    "\n2. Motorcycle" +
                    "\n3. Car" +
                    "\n4. Bus" +
                    "\n5. Boat" +
                    "\n0. Exit");
                if (Enum.TryParse<VehicleType>(uiManager.ReadMessage(), out var type) && Enum.IsDefined(typeof(VehicleType), type))
                {
                    return type;
                }
                else
                {
                    uiManager.MessageLine("Invalid selection. Please try again.");
                }
            }
        }

        private string GetValidatedRegNo()
        {
            while (true)
            {
                string regNo = uiManager.GetInput("Registration number (6 characters, no spaces): ");
                if (regNo.Length == 6 && !regNo.Contains(" ") && !commandHandler.RegistrationNumberExists(regNo))
                {
                    return regNo;
                }
                else
                {
                    uiManager.MessageLine("Invalid or duplicate registration number. Please try again.");
                }
            }
        }

        private int GetValidNumberOfWheels()
        {
            int nrOfWheels;
            while (true)
            {
                string input = uiManager.GetInput("Number of wheels (0-100): ");
                if (int.TryParse(input, out nrOfWheels) && nrOfWheels >= 0 && nrOfWheels <= 100)
                {
                    return nrOfWheels;
                }
                else
                {
                    uiManager.MessageLine("Invalid number of wheels. Please enter a number between 0 and 100.");
                }
            }
        }

        private void AddVehicle()
        {
            if (commandHandler.IsParkingFull())
            {
                uiManager.MessageLine("Parking is full.");
                return;
            }

            var typeOfVehicle = GetVehicleTypeFromUser();
            if (typeOfVehicle == VehicleType.None) return;

            string regNo = GetValidatedRegNo();
            string color = uiManager.GetInput("Vehicle color: ");
            int nrOfWheels = GetValidNumberOfWheels(); 
            AddVehicleByType(typeOfVehicle, regNo, color, nrOfWheels);
        }

        private void AddVehicleByType(VehicleType type, string regNo, string color, int nrOfWheels)
        {
            switch (type)
            {
                case VehicleType.Airplane:
                    var numberOfEngines = uiManager.GetNumberInput("Enter number of engines: ");
                    commandHandler.AddAirplane(regNo, color, nrOfWheels, numberOfEngines);
                    uiManager.MessageLine("Airplane added successfully.");
                    break;
                case VehicleType.Motorcycle:
                    var cylinderVolume = uiManager.GetNumberInput("Enter cylinder volume: ");
                    commandHandler.AddMotorcycle(regNo, color, nrOfWheels, cylinderVolume);
                    uiManager.MessageLine("Motorcycle added successfully.");
                    break;
                case VehicleType.Car:
                    string fuelType = uiManager.GetInput("Enter fuel type: ");
                    commandHandler.AddCar(regNo, color, nrOfWheels, fuelType);
                    uiManager.MessageLine("Car added successfully.");
                    break;
                case VehicleType.Bus:
                    int numberOfSeats = uiManager.GetNumberInput("Enter number of seats: ");
                    commandHandler.AddBus(regNo, color, nrOfWheels, numberOfSeats);
                    uiManager.MessageLine("Bus added successfully.");
                    break;
                case VehicleType.Boat:
                    double length = uiManager.GetDoubleInput("Enter length : ");
                    commandHandler.AddBoat(regNo, color, nrOfWheels, length);
                    uiManager.MessageLine("Boat added successfully.");
                    break;
                case VehicleType.None:                    
                    break;
                default:
                    uiManager.MessageLine("Vehicle added successfully.");
                    break;
            }
        }


    }
}
