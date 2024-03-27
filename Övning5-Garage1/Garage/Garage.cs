using Övning5_Garage1.Interface;
using Övning5_Garage1.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5_Garage1.Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicleArray;
        private int capacity;

        public int NumberOfVehiclesInParking { get; private set; } = 0;

        public Garage(int capacity)
        {
            this.capacity = capacity;
            vehicleArray = new T[capacity];
        }



        public bool AddItem(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            }

            for (int i = 0; i < vehicleArray.Length; i++)
            {
                if (vehicleArray[i] == null)
                {
                    vehicleArray[i] = item;
                    NumberOfVehiclesInParking++;
                    return true;
                }
            }
            return false;
        }
        public bool CheckIsParkingFull()
        {
            return NumberOfVehiclesInParking >= capacity;
        }



        public bool RemoveItem(int vehicleToRemove)
        {

            if (vehicleToRemove < 0 || vehicleToRemove >= vehicleArray.Length)
            {
                Console.WriteLine("Error: Index out of bounds.");

                return false;
            }

            if (vehicleArray[vehicleToRemove] == null)
            {
                Console.WriteLine("Error: No vehicle to remove at the specified index.");
                return false;
            }

            vehicleArray[vehicleToRemove] = null!;

            for (int i = vehicleToRemove; i < NumberOfVehiclesInParking - 1; i++)
            {
                vehicleArray[i] = vehicleArray[i + 1];
            }

            vehicleArray[NumberOfVehiclesInParking - 1] = null!;

            NumberOfVehiclesInParking--;

            return true;
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in vehicleArray)
            {
                if (vehicle != null)
                    yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
