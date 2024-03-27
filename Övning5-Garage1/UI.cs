using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Övning5_Garage1.Interface;
using Övning5_Garage1.Garage;

namespace Övning5_Garage1
{
    public class UI : IUI
    {

        public void MessageLine(string message)
        {
            Console.WriteLine(message);
        }
        public string ReadMessage()
        {
            return Console.ReadLine();
        }

        public double GetDoubleInput(string inputText)
        {
            double respondNumber;
            bool isValid = false;
            do
            {
                string inputRead = GetInput(inputText);
                isValid = double.TryParse(inputRead, NumberStyles.Any, CultureInfo.InvariantCulture, out respondNumber);

                if (!isValid)
                {
                    MessageLine("Wrong input. Enter valid input");
                }

            }
            while (!isValid);

            return respondNumber;
        }

        public string GetInput(string inputText)
        {
            while (true)
            {
                Console.WriteLine(inputText);
                string inputRead = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputRead))
                {
                    return inputRead;
                }

                Console.WriteLine("Invalid input. Please enter a valid value.");
            }
        }





        public int GetNumberInput(string inputText)
        {
            int respondNumber;
            while (true)
            {

                string inputRead = GetInput($"{inputText} (Enter a valid integer):");

                if (int.TryParse(inputRead, out respondNumber))
                {
                    return respondNumber;
                }

                MessageLine("Invalid input. Please enter a valid integer.");
            }
        }




        public int GetSizeParking(string inputPrompt)
        {
            int parkingSize;
            while (true)
            {
                string inputRead = GetInput($"{inputPrompt} (Enter a number between 20 and 1000):");

                if (int.TryParse(inputRead, out parkingSize) && parkingSize >= 20 && parkingSize <= 1000)
                {
                    return parkingSize;
                }

                MessageLine("Invalid input. Please enter a number between 20 and 1000.");
            }
        }


        public bool GetConfirmation(string message)
        {
            while (true)
            {
                Console.Write($"{message} (y/n): ");
                string response = Console.ReadLine()?.Trim().ToLower();

                if (response == "y" || response == "yes")
                {
                    return true;
                }
                else if (response == "n" || response == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no.");
                }
            }
        }
    }



}

