using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5_Garage1.Interface
{
    public interface IUI
    {
        string GetInput(string inputText);        
        int GetNumberInput(string inputText);
        void MessageLine(string message);
        int GetSizeParking(string numberOfCars);
        double GetDoubleInput(string length);

        public bool GetConfirmation(string message);
        string ReadMessage();
    }
}
